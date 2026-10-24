using System;
using System.Collections.Generic;
using System.Drawing;

namespace LSystemApp
{
    public class TurtleInterpreter
    {
        private readonly LSystem _system;
        private readonly double _step;
        private readonly Random _rand = new Random();

        public List<PointF[]> Segments { get; } = new List<PointF[]>();

        //============Бочарова 1.б========================
        public List<int> Depths { get; } = new List<int>(); // глубина каждого отрезка
        public int MaxDepth { get; private set; } = 0;
        //================================================

        public TurtleInterpreter(LSystem system, double step = 1.0)
        {
            _system = system;
            _step = step;
        }

        public void Interpret(string command)
        {
            Segments.Clear();
            //============Бочарова 1.б========================
            Depths.Clear();
            MaxDepth = 0;
            //================================================

            double angleRad = _system.Angle * Math.PI / 180.0;
            double randomFactor = _system.Randomness;

            // Начальное состояние черепахи
            double x = 0, y = 0;
            double dir = _system.InitialDirection * Math.PI / 180.0;

            var stack = new Stack<(double x, double y, double dir)>();

            foreach (char c in command)
            {
                switch (c)
                {
                    // ── Рисующие символы ───────────────────────────────
                    case 'F':
                    case 'G':
                    case 'A':
                    case 'B':
                    case 'X':
                    case 'Y':
                        {
                            double nx = x + _step * Math.Cos(dir); //полярные координаты
                            double ny = y + _step * Math.Sin(dir);
                            Segments.Add(new[]
                            {
                                new PointF((float)x, (float)y),
                                new PointF((float)nx, (float)ny)
                            });
                            //============Бочарова 1.б========================
                            Depths.Add(stack.Count); // фиксируем глубину отрезка, чтобы определить толщину и цвет
                            if (stack.Count > MaxDepth) MaxDepth = stack.Count;
                            //================================================
                            x = nx; y = ny;
                            break;
                        }

                    // ── Перемещение без рисования ──────────────────────
                    case 'f':
                    case 'g':
                        {
                            x += _step * Math.Cos(dir);
                            y += _step * Math.Sin(dir);
                            break;
                        }

                    // ── Повороты ───────────────────────────────────────
                    case '+':
                        dir += ApplyRandom(angleRad, randomFactor);
                        break;
                    case '-':
                        dir -= ApplyRandom(angleRad, randomFactor);
                        break;
                    case '|':
                        dir += Math.PI;
                        break;

                    // ── СТЕК ───────────────────────────────────────────
                    case '[':
                        stack.Push((x, y, dir));
                        break;
                    case ']':
                        if (stack.Count > 0)
                        {
                            var s = stack.Pop(); //для ветвления кустов и деревьев
                            x = s.x; y = s.y; dir = s.dir;
                        }
                        break;

                    // ── СЛУЧАЙНОСТЬ @ ──────────────────────────────────
                    case '@':
                        double randomOffset = (_rand.NextDouble() * 30.0 - 15.0) * Math.PI / 180.0;
                        dir += randomOffset;
                        break;

                    // Все прочие символы (X, Y и т.п.) игнорируются.
                    default:
                        break;
                }
            }
        }

        private double ApplyRandom(double baseAngle, double randomFactor)
        {
            if (randomFactor <= 0) return baseAngle;
            // Случайное отклонение в пределах ±randomFactor * baseAngle
            double delta = (2 * _rand.NextDouble() - 1) * randomFactor * baseAngle;
            return baseAngle + delta;
        }

        public List<PointF[]> FitToBounds(RectangleF bounds, float margin = 10f)
        {
            var result = new List<PointF[]>(Segments.Count);
            if (Segments.Count == 0) return result;

            // Находим габариты всех точек
            float minX = float.MaxValue, minY = float.MaxValue;
            float maxX = float.MinValue, maxY = float.MinValue;

            foreach (var seg in Segments)
                foreach (var p in seg)
                {
                    if (p.X < minX) minX = p.X;
                    if (p.Y < minY) minY = p.Y;
                    if (p.X > maxX) maxX = p.X;
                    if (p.Y > maxY) maxY = p.Y;
                }

            //защита от нулевых
            float w = maxX - minX;
            float h = maxY - minY;
            if (w <= 1e-6f) w = 1;
            if (h <= 1e-6f) h = 1;

            float availW = bounds.Width - 2 * margin; //отступ от краев
            float availH = bounds.Height - 2 * margin;
            if (availW <= 0) availW = 1;
            if (availH <= 0) availH = 1;

            float scale = Math.Min(availW / w, availH / h); //минимум, чтобы не вылез за границы окна

            // Смещение для центрирования
            float offsetX = (availW - w * scale) / 2f;
            float offsetY = (availH - h * scale) / 2f;

            // Переносим точки в экранные координаты
            foreach (var seg in Segments)
            {
                var newSeg = new PointF[seg.Length];
                for (int i = 0; i < seg.Length; i++)
                {
                    float sx = bounds.Left + margin + offsetX + (seg[i].X - minX) * scale;
                    // Инвертируем Y: логический Y вверх -> экранный Y вниз
                    float sy = bounds.Bottom - margin - offsetY - (seg[i].Y - minY) * scale;
                    newSeg[i] = new PointF(sx, sy);
                }
                result.Add(newSeg);
            }

            return result;
        }
    }
}