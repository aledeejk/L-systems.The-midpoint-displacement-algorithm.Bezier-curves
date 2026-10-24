using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace LSystemApp
{
    public class LSystem
    {
        public string Axiom { get; set; } = "F";
        public double Angle { get; set; } = 90.0;
        public double InitialDirection { get; set; } = 90.0;
        public Dictionary<char, string> Rules { get; } = new Dictionary<char, string>();
        public double Randomness { get; set; } = 0.0;

        public string Generate(int iterations)
        {
            string current = Axiom;
            for (int i = 0; i < iterations; i++)
            {
                var sb = new StringBuilder();
                foreach (char c in current)
                {
                    if (Rules.TryGetValue(c, out string replacement))
                        sb.Append(replacement);
                    else
                        sb.Append(c);
                }
                current = sb.ToString();
            }
            return current;
        }

        public static LSystem LoadFromFile(string path)
        {
            var system = new LSystem();
            string[] lines = File.ReadAllLines(path);
            bool headerParsed = false;

            foreach (string raw in lines)
            {
                string line = raw.Trim();
                if (line.Length == 0 || line.StartsWith("#")) continue;

                if (!headerParsed)
                {
                    string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 1) throw new FormatException("Некорректный заголовок.");
                    system.Axiom = parts[0];
                    if (parts.Length > 1) system.Angle = double.Parse(parts[1], CultureInfo.InvariantCulture);
                    if (parts.Length > 2) system.InitialDirection = double.Parse(parts[2], CultureInfo.InvariantCulture);
                    headerParsed = true;
                }
                else
                {
                    int arrow = line.IndexOf("->", StringComparison.Ordinal);
                    if (arrow < 0) continue;
                    string left = line.Substring(0, arrow).Trim();
                    string right = line.Substring(arrow + 2).Trim();
                    if (left.Length != 1) throw new FormatException($"Ошибка в правиле: '{line}'");
                    system.Rules[left[0]] = right;
                }
            }
            return system;
        }
    }
}