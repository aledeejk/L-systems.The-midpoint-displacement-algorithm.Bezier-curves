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

        // Переменные для 3 (Безье) 
        private List<PointF> _bezierPoints = new List<PointF>();
        private int _draggingBezierPointIndex = -1;

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

        public MainForm()
        {
            InitializeComponent();

            // Заполняем ComboBox
            foreach (var key in _presets.Keys)
                cmbPresets.Items.Add(key);
            cmbPresets.SelectedIndex = 0;

            // ── Подписки на события для L-систем ───────────────────────
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

            numRandom.ValueChanged += (s, e) =>
            {
                _randomness = (double)numRandom.Value / 100.0;
                Redraw();
            };

            btnLoad.Click += (s, e) => LoadFromFile();
            btnRedraw.Click += (s, e) => Redraw();

            panelCanvas.Paint += Canvas_Paint;
            panelCanvas.Resize += (s, e) => Redraw();

            //  Подписки на события для Безье 
            panelBezierCanvas.Paint += PanelBezierCanvas_Paint;
            panelBezierCanvas.MouseDown += PanelBezierCanvas_MouseDown;
            panelBezierCanvas.MouseMove += PanelBezierCanvas_MouseMove;
            panelBezierCanvas.MouseUp += PanelBezierCanvas_MouseUp;

            LoadPreset();
        }

        // МЕТОДЫ ДЛЯ L-СИСТЕМ 

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

            _segments = interp.FitToBounds(panelCanvas.ClientRectangle, 15f);

            lblInfo.Text = $"Точек: {_segments.Count}";
            panelCanvas.Invalidate();
        }

        private void Canvas_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            using (var pen = new Pen(Color.FromArgb(135, 206, 235), 1.5f))
            {
                foreach (var seg in _segments)
                {
                    if (seg.Length >= 2)
                        e.Graphics.DrawLines(pen, seg);
                }
            }
        }

        // ЛОГИКА ДЛЯ КРИВЫХ БЕЗЬЕ 

        private void PanelBezierCanvas_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 1. Рисуем пунктирные линии между точками 
            if (_bezierPoints.Count > 1)
            {
                using (Pen dashedPen = new Pen(Color.LightGray, 1))
                {
                    dashedPen.DashStyle = DashStyle.Dash;
                    for (int i = 0; i < _bezierPoints.Count - 1; i++)
                    {
                        g.DrawLine(dashedPen, _bezierPoints[i], _bezierPoints[i + 1]);
                    }
                }
            }

            // 2. Рисуем саму кривую Безье
            if (_bezierPoints.Count >= 4)
            {
                using (Pen curvePen = new Pen(Color.Blue, 3))
                {
                    for (int i = 0; i <= _bezierPoints.Count - 4; i++)
                    {
                        g.DrawBezier(curvePen, _bezierPoints[i], _bezierPoints[i + 1], _bezierPoints[i + 2], _bezierPoints[i + 3]);
                    }
                }
            }
            else if (_bezierPoints.Count > 1)
            {
                using (Pen simplePen = new Pen(Color.Blue, 2))
                {
                    for (int i = 0; i < _bezierPoints.Count - 1; i++)
                    {
                        g.DrawLine(simplePen, _bezierPoints[i], _bezierPoints[i + 1]);
                    }
                }
            }

            // 3. Рисуем сами опорные точки
            foreach (PointF p in _bezierPoints)
            {
                g.FillEllipse(Brushes.Red, p.X - 5, p.Y - 5, 10, 10);
                g.DrawEllipse(Pens.Black, p.X - 5, p.Y - 5, 10, 10);
            }
        }

        private void PanelBezierCanvas_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < _bezierPoints.Count; i++)
                {
                    if (Math.Abs(_bezierPoints[i].X - e.X) < 10 && Math.Abs(_bezierPoints[i].Y - e.Y) < 10)
                    {
                        _draggingBezierPointIndex = i;
                        return;
                    }
                }
                _bezierPoints.Add(new PointF(e.X, e.Y));
                panelBezierCanvas.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < _bezierPoints.Count; i++)
                {
                    if (Math.Abs(_bezierPoints[i].X - e.X) < 10 && Math.Abs(_bezierPoints[i].Y - e.Y) < 10)
                    {
                        _bezierPoints.RemoveAt(i);
                        _draggingBezierPointIndex = -1;
                        panelBezierCanvas.Invalidate();
                        return;
                    }
                }
            }
        }

        private void PanelBezierCanvas_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_draggingBezierPointIndex != -1 && e.Button == MouseButtons.Left)
            {
                _bezierPoints[_draggingBezierPointIndex] = new PointF(e.X, e.Y);
                panelBezierCanvas.Invalidate();
            }
        }

        private void PanelBezierCanvas_MouseUp(object? sender, MouseEventArgs e)
        {
            _draggingBezierPointIndex = -1;
        }
    }
}