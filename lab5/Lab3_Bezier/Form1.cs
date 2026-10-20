using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab3_Bezier
{
    public partial class Form1 : Form
    {
        // Список всех опорных точек (точек, которые мы двигаем)
        private List<PointF> points = new List<PointF>();

        // Индекс точки, которую сейчас тащим (-1, если ничего не тащим)
        private int draggingPointIndex = -1;

        public Form1()
        {
            InitializeComponent();

            // Настройки формы для плавной отрисовки
            this.DoubleBuffered = true; // Убирает мерцание
            this.BackColor = Color.White;
            this.Text = "Кубические сплайны Безье (Управление точками)";
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.Paint += Form1_Paint;
        }

        // --- Отрисовка ---
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Сглаживание

            // 1. Рисуем линии, соединяющие точки (чтобы видеть структуру)
            if (points.Count > 1)
            {
                using (Pen dashedPen = new Pen(Color.LightGray, 1))
                {
                    dashedPen.DashStyle = DashStyle.Dash;
                    // Соединяем точки попарно, чтобы видеть "скелет"
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        g.DrawLine(dashedPen, points[i], points[i + 1]);
                    }
                }
            }

            // 2. Рисуем саму кривую Безье (составную)
            // Кубическая кривая Безье строится по 4 точкам.
            // Чтобы сделать "составную" (spline), мы соединяем сегменты.
            // Если у нас, например, 5 точек, мы можем построить 2 сегмента:
            // Сегмент 1: точки 0, 1, 2, 3
            // Сегмент 2: точки 1, 2, 3, 4 (или 3,4,5,6 - зависит от логики)
            // В простейшем случае для плавности мы используем каждые 4 точки.

            // Для наглядности нарисуем кривую, используя все доступные точки как "опорные"
            // В реальном сплайне точки должны быть соединены в цепочку.
            // Здесь мы просто демонстрируем, как кривая "обтекает" точки.

            if (points.Count >= 4)
            {
                // Рисуем составную кривую: каждый следующий сегмент начинается
                // с предыдущей конечной точки (или близкой к ней), но для простоты
                // просто рисуем Bezier по 4-м точкам подряд.
                // ВНИМАНИЕ: Для идеальной гладкости в составных сплайнах
                // используются B-сплайны, но в задании сказано "Кубические сплайны Безье".

                using (Pen curvePen = new Pen(Color.Blue, 3))
                {
                    // Рисуем кривую по 4 точкам.
                    // Если точек больше 4, мы можем рисовать несколько сегментов.
                    // Например, для 5 точек: рисуем по (0,1,2,3), затем по (1,2,3,4).
                    for (int i = 0; i <= points.Count - 4; i++)
                    {
                        g.DrawBezier(curvePen, points[i], points[i + 1], points[i + 2], points[i + 3]);
                    }
                }
            }
            else if (points.Count > 1)
            {
                // Если точек меньше 4, рисуем просто линии (чтобы было видно)
                using (Pen simplePen = new Pen(Color.Blue, 2))
                {
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        g.DrawLine(simplePen, points[i], points[i + 1]);
                    }
                }
            }

            // 3. Рисуем сами точки (кружочки)
            foreach (PointF p in points)
            {
                g.FillEllipse(Brushes.Red, p.X - 5, p.Y - 5, 10, 10);
                g.DrawEllipse(Pens.Black, p.X - 5, p.Y - 5, 10, 10);
            }
        }

        // --- Обработка мыши ---

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Ищем, попали ли мы в существующую точку
                for (int i = 0; i < points.Count; i++)
                {
                    // Проверяем расстояние (радиус клика = 10 пикселей)
                    if (Math.Abs(points[i].X - e.X) < 10 && Math.Abs(points[i].Y - e.Y) < 10)
                    {
                        draggingPointIndex = i; // Запоминаем, что тащим эту точку
                        return;
                    }
                }

                // Если не попали в точку — добавляем новую
                points.Add(new PointF(e.X, e.Y));
                Invalidate(); // Перерисовать
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Удаление точки (правый клик)
                for (int i = 0; i < points.Count; i++)
                {
                    if (Math.Abs(points[i].X - e.X) < 10 && Math.Abs(points[i].Y - e.Y) < 10)
                    {
                        points.RemoveAt(i);
                        draggingPointIndex = -1;
                        Invalidate();
                        return;
                    }
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Если мы тащим какую-то точку
            if (draggingPointIndex != -1 && e.Button == MouseButtons.Left)
            {
                points[draggingPointIndex] = new PointF(e.X, e.Y);
                Invalidate(); // Перерисовать в реальном времени
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Отпустили кнопку — перестаем тащить
            draggingPointIndex = -1;
        }
    }
}