using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace LSystemApp
{
    public partial class MainForm : Form
    {
        private LSystem _system;
        private List<PointF[]> _segments = new List<PointF[]>();
        private int _iterations = 4;
        private double _randomness = 0.0;

        //============Бочарова 1.б========================
        private TurtleInterpreter _lastInterp;
        //================================================

        // ── Встроенные предустановки (из лекции) ────────────────────────
        private readonly Dictionary<string, string> _presets = new Dictionary<string, string>
        {
            ["Кривая Коха"] =
                "F 60 0\n" +
                "F->F-F++F-F",

            ["Снежинка Коха"] =
                "F++F++F 60 0\n" +
                "F->F-F++F-F",

            ["Квадратный остров Коха"] =
                "F+F+F+F 90 0\n" +
                "F->F+F-F-FF+F+F-F",

            ["Кривая Гильберта"] =
                "X 90 0\n" +
                "X->-YF+XFX+FY-\n" +
                "Y->+XF-YFY-FX+",

            ["Кривая Дракона"] =
                "FX 90 0\n" +
                "X->X+YF+\n" +
                "Y->-FX-Y\n" +
                "F->F",

            ["Наконечник Серпинского"] =
                "YF 60 0\n" +
                "X->YF+XF+Y\n" +
                "Y->XF-YF-X\n" +
                "F->F",

            ["Шестиугольная кривая Госпера"] =
                "XF 60 0\n" +
                "X->X+YF++YF-FX--FXFX-YF+\n" +
                "Y->-FX+YFYF++YF+FX--FX-Y\n" +
                "F->F",

            ["Куст 1"] =
                "F 22 90\n" +
                "F->FF-[-F+F+F]+[+F-F-F]",

            ["Куст 2"] =
                "X 20 90\n" +
                "F->FF\n" +
                "X->F[+X]F[-X]+X",

            ["Куст 3"] =
                "X 22.5 90\n" +
                "F->FF\n" +
                "X->F-[[X]+X]+F[+FX]-X"
        };

        //============Бочарова========================
        private MidpointDisplacement _midpoint;
        private int _midpointSeed = 0;
        //============================================

        public MainForm()
        {
            InitializeComponent();

            // Заполняем ComboBox
            foreach (var key in _presets.Keys)
                cmbPresets.Items.Add(key);
            cmbPresets.SelectedIndex = 0;

            // ── Подписки на события ────────────────────────────────────
            cmbPresets.SelectedIndexChanged += (s, e) => LoadPreset();

            numIterations.ValueChanged += (s, e) =>
            {
                _iterations = (int)numIterations.Value;
                Redraw();
            };

            chkRandom.CheckedChanged += (s, e) =>
            {
                numRandom.Enabled = chkRandom.Checked;
                Redraw();
            };

            chkTreeStyle.CheckedChanged += (s, e) => Redraw();

            numRandom.ValueChanged += (s, e) =>
            {
                _randomness = (double)numRandom.Value / 100.0;
                Redraw();
            };

            btnLoad.Click += (s, e) => LoadFromFile();
            btnRedraw.Click += (s, e) => Redraw();

            panelCanvas.Paint += Canvas_Paint;
            panelCanvas.Resize += (s, e) => Redraw();

            LoadPreset();

            //============Бочарова========================
            _midpoint = new MidpointDisplacement(_midpointSeed)
            {
                MaxLevels = (int)numMidIterations.Value,
                Roughness = (float)numRoughness.Value,
                StartHeight = (float)numMidStartPoint.Value,
                EndHeight = (float)numMidEndPoint.Value
            };
            _midpoint.Reset(_midpointSeed);

            numMidIterations.ValueChanged += (s, e) => { _midpoint.MaxLevels = (int)numMidIterations.Value; ResetMidpoint(false); };
            numRoughness.ValueChanged += (s, e) => { _midpoint.Roughness = (float)numRoughness.Value; ResetMidpoint(false); };
            numMidSeed.ValueChanged += (s, e) => { _midpointSeed = (int)numMidSeed.Value; ResetMidpoint(false); };
            numMidStartPoint.ValueChanged += (s, e) => { _midpoint.StartHeight = (float)numMidStartPoint.Value; ResetMidpoint(true); };
            numMidEndPoint.ValueChanged += (s, e) => { _midpoint.EndHeight = (float)numMidEndPoint.Value; ResetMidpoint(true); };
            btnMidReset.Click += (s, e) => ResetMidpoint(true);
            btnMidStep.Click += (s, e) => { _midpoint.NextStep(); RedrawMidpoint(); };
            btnMidRun.Click += (s, e) => { _midpoint.RunToEnd(); RedrawMidpoint(); };
            panelMidCanvas.Paint += MidCanvas_Paint;
            panelMidCanvas.Resize += (s, e) => RedrawMidpoint();

            RedrawMidpoint();
            //============================================
        }

        private void LoadPreset()
        {
            string name = cmbPresets.SelectedItem?.ToString();
            if (name == null || !_presets.ContainsKey(name)) return;

            // Парсим строку через временный файл — так проще всего переиспользовать парсер
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, _presets[name]);
                _system = LSystem.LoadFromFile(tempFile);
            }
            finally
            {
                try { File.Delete(tempFile); } catch { /* ignore */ }
            }
            Redraw();
        }

        private void LoadFromFile()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _system = LSystem.LoadFromFile(ofd.FileName);
                        Redraw();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки: " + ex.Message);
                    }
                }
            }
        }

        private void Redraw()
        {
            if (_system == null || panelCanvas == null) return;

            _system.Randomness = chkRandom.Checked ? _randomness : 0.0;

            string command = _system.Generate(_iterations);

            var interp = new TurtleInterpreter(_system, step: 1.0);
            interp.Interpret(command);
            _lastInterp = interp;

            _segments = interp.FitToBounds(panelCanvas.ClientRectangle, 15f);

            lblInfo.Text = $"Точек: {_segments.Count}";
            panelCanvas.Invalidate();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);


            //============Бочарова========================
            if (chkTreeStyle.Checked && _lastInterp != null)
                DrawStyledTree(e.Graphics);
            else
                DrawPlain(e.Graphics);
        }

        private void DrawPlain(Graphics g)
        {
            using (var pen = new Pen(Color.FromArgb(135, 206, 235), 1.5f))
            {
                foreach (var seg in _segments)
                    if (seg.Length >= 2)
                        g.DrawLines(pen, seg);
            }
        }

        private void DrawStyledTree(Graphics g)
        {
            int maxDepth = Math.Max(1, _lastInterp.MaxDepth);
            const float baseWidth = 4.0f;
            const float tipWidth = 0.6f;
            Color baseColor = Color.FromArgb(101, 67, 33);   // коричневый
            Color tipColor = Color.FromArgb(34, 139, 34);   // зелёный

            int count = Math.Min(_segments.Count, _lastInterp.Depths.Count);
            for (int i = 0; i < count; i++)
            {
                var seg = _segments[i];
                if (seg.Length < 2) continue;

                float t = _lastInterp.Depths[i] / (float)maxDepth;  // 0 = ствол, 1 = кончик
                float width = baseWidth + (tipWidth - baseWidth) * t;
                Color color = LerpColor(baseColor, tipColor, t);

                using (var pen = new Pen(color, width) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                    g.DrawLines(pen, seg);
            }
        }

        private static Color LerpColor(Color a, Color b, float t)
        {
            t = Math.Clamp(t, 0f, 1f);
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t));
        }

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelMidStartPoint_Click(object sender, EventArgs e)
        {

        }

        private void ResetMidpoint(bool needToRedrawMidpoint)
        {
            _midpoint.Reset(_midpointSeed);

            if (needToRedrawMidpoint) RedrawMidpoint();
        }

        private void RedrawMidpoint()
        {
            if (panelMidCanvas == null || _midpoint == null) return;
            lblMidInfo.Text = $"Шаг: {_midpoint.Level} / {_midpoint.MaxLevels}, точек: {_midpoint.Points.Count}";
            panelMidCanvas.Invalidate();
        }

        private void MidCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            var pts = _midpoint.Points;
            if (pts.Count < 2) return;

            int w = panelMidCanvas.ClientSize.Width;
            int h = panelMidCanvas.ClientSize.Height;
            int margin = 20;

            float stepX = (w - 2f * margin) / (pts.Count - 1);
            float drawH = h - 2f * margin;        // доступная высота
            float baseY = h - margin;             // линия земли (value = 0)

            var points = new PointF[pts.Count];
            for (int i = 0; i < pts.Count; i++)
            {
                float x = margin + i * stepX;
                // clamp на случай выхода за пределы из-за roughness
                float v = Math.Clamp(pts[i], 0f, 1f);
                float y = baseY - v * drawH;
                points[i] = new PointF(x, y);
            }

            // Заливка под ломаной — «горы» (до линии земли)
            using (var fillBrush = new SolidBrush(Color.FromArgb(60, 100, 149, 237)))
            {
                var poly = new PointF[points.Length + 2];
                Array.Copy(points, poly, points.Length);
                poly[points.Length] = new PointF(points[points.Length - 1].X, baseY);
                poly[points.Length + 1] = new PointF(points[0].X, baseY);
                e.Graphics.FillPolygon(fillBrush, poly);
            }

            using (var pen = new Pen(Color.FromArgb(50, 80, 160), 1.5f))
                e.Graphics.DrawLines(pen, points);

            // Крайние точки (только две — концы)
            using (var dot = new SolidBrush(Color.Red))
            {
                e.Graphics.FillEllipse(dot, points[0].X - 3f, points[0].Y - 3f, 6, 6);
                e.Graphics.FillEllipse(dot, points[points.Length - 1].X - 3f,
                                       points[points.Length - 1].Y - 3f, 6, 6);
            }
        }

        //============================================
    }
}