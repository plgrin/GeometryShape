using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GeometricShape.Entities;
using GeometricShape.Actions;

namespace GeometricShape.Validators
{
    public static class Validators
    {
        private const string POINT_REGEX = @"^-?\d+(\.\d+)?\s-?\d+(\.\d+)?$";

        public static bool ValidatePoint(string line, out GeometricShape.Entities.Point point)
        {
            point = null;
            if (!Regex.IsMatch(line, POINT_REGEX))
            {
                return false;
            }

            var parts = line.Split(' ');
            if (double.TryParse(parts[0], out double x) && double.TryParse(parts[1], out double y))
            {
                point = new GeometricShape.Entities.Point(x, y);
                return true;
            }

            return false;
        }

        public static bool ValidateRectangle(string name, List<GeometricShape.Entities.Point> points, out Rectangle rectangle)
        {
            rectangle = null;
            if (points.Count != 4)
            {
                return false;
            }

            if (RectangleActions.ArePointsRectangle(points))
            {
                rectangle = new Rectangle(name, points);
                return true;
            }

            return false;
        }
    }
}
