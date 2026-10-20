using System;
using System.Collections.Generic;

namespace LSystemApp
{
    // Алгоритм midpoint displacement для генерации профиля горного массива (ломаной линии)
    public class MidpointDisplacement
    {
        private Random _rand;
        private List<float> _points = new List<float>();

        //Текущий уровень детализации (число выполненных итераций)
        public int Level { get; private set; } = 0;

        //Максимальное число итераций (задаётся извне)
        public int MaxLevels { get; set; } = 8;

        //Шероховатость (roughness) — главный параметр алгоритма
        public float Roughness { get; set; } = 0.7f;

        //Начальная высота левого края
        public float StartHeight { get; set; } = 0.5f;

        //Начальная высота правого края
        public float EndHeight { get; set; } = 0.5f;

        public bool IsFinished => Level >= MaxLevels;
        public IReadOnlyList<float> Points => _points;

        public MidpointDisplacement(int seed = 0)
        {
            _rand = new Random(seed);
        }

        //Сброс и инициализация
        public void Reset(int seed = 0)
        {
            _rand = new Random(seed);
            _points = new List<float> { StartHeight, EndHeight };
            Level = 0;
        }

        //Один шаг алгоритма: найти все середины текущих отрезков и сместить их на случайную величину
        public void NextStep()
        {
            if (IsFinished) return;

            // Величина смещения пропорциональна длине отрезка,
            // которая на уровне L равна 1 / 2^L от исходной
            float displacement = Roughness / (float)Math.Pow(2, Level + 1);

            var newPoints = new List<float>(_points.Count * 2 - 1);
            for (int i = 0; i < _points.Count - 1; i++)
            {
                newPoints.Add(_points[i]);

                float mid = (_points[i] + _points[i + 1]) / 2f;
                float offset = (float)(_rand.NextDouble() * 2 - 1) * displacement;
                newPoints.Add(mid + offset);
            }
            newPoints.Add(_points[_points.Count - 1]);

            _points = newPoints;
            Level++;
        }

        // Выполнить все шаги сразу
        public void RunToEnd()
        {
            while (!IsFinished) NextStep();
        }
    }
}
