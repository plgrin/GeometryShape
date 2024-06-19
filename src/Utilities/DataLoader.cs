using System;
using System.Collections.Generic;
using System.IO;
using GeometricShape.Entities;
using GeometricShape.Validators;
using GeometricShape.Factories;

namespace GeometricShape.Utilities
{
    public static class DataLoader
    {
        private static readonly ShapeFactory shapeFactory = new ConcreteShapeFactory();

        public static List<Rectangle> LoadRectangles(string filePath)
        {
            var rectangles = new List<Rectangle>();
            var lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i += 5)
            {
                if (i + 4 >= lines.Length)
                {
                    break;
                }

                string name = lines[i];
                var points = new List<Point>();

                for (int j = 1; j <= 4; j++)
                {
                    if (Validators. Validators.ValidatePoint(lines[i + j], out Point point))
                    {
                        points.Add(shapeFactory.CreatePoint(point.X, point.Y));
                    }
                    else
                    {
                        break;
                    }
                }

                if (Validators.Validators.ValidateRectangle(name, points, out Rectangle rectangle))
                {
                    rectangles.Add(shapeFactory.CreateRectangle(name, points));
                }
                else
                {
                    Console.WriteLine($"Invalid data for rectangle starting at line {i + 1}");
                }
            }

            return rectangles;
        }
    }
}
