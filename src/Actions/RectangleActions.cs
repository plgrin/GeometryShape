using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometricShape.Entities;

namespace GeometricShape.Actions
{
    public static class RectangleActions
    {
        public static double CalculateArea(Rectangle rectangle)
        {
            Point a = rectangle.Points[0];
            Point b = rectangle.Points[1];
            Point c = rectangle.Points[2];

            double width = Distance(a, b);
            double height = Distance(b, c);

            return width * height;
        }

        public static double CalculatePerimeter(Rectangle rectangle)
        {
            Point a = rectangle.Points[0];
            Point b = rectangle.Points[1];
            Point c = rectangle.Points[2];

            double width = Distance(a, b);
            double height = Distance(b, c);

            return 2 * (width + height);
        }

        public static bool IsSquare(Rectangle rectangle)
        {
            Point a = rectangle.Points[0];
            Point b = rectangle.Points[1];
            Point c = rectangle.Points[2];

            double width = Distance(a, b);
            double height = Distance(b, c);

            return width == height;
        }

        private static double Distance(Point p1, Point p2)
        {
            double xDiff = p2.X - p1.X;
            double yDiff = p2.Y - p1.Y;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        public static bool ArePointsRectangle(List<Point> points)
        {
            if (points.Count != 4)
            {
                return false;
            }

            double d1 = Distance(points[0], points[1]);
            double d2 = Distance(points[1], points[2]);
            double d3 = Distance(points[2], points[3]);
            double d4 = Distance(points[3], points[0]);

            double diag1 = Distance(points[0], points[2]);
            double diag2 = Distance(points[1], points[3]);

            return d1 == d3 && d2 == d4 && diag1 == diag2;
        }

        public static bool IsConvexQuadrilateral(Rectangle rectangle)
        {
            Point a = rectangle.Points[0];
            Point b = rectangle.Points[1];
            Point c = rectangle.Points[2];
            Point d = rectangle.Points[3];

            return IsConvex(a, b, c, d);
        }

        private static bool IsConvex(Point a, Point b, Point c, Point d)
        {
            double crossProduct1 = CrossProduct(a, b, c);
            double crossProduct2 = CrossProduct(b, c, d);
            double crossProduct3 = CrossProduct(c, d, a);
            double crossProduct4 = CrossProduct(d, a, b);

            return (crossProduct1 > 0 && crossProduct2 > 0 && crossProduct3 > 0 && crossProduct4 > 0) ||
                   (crossProduct1 < 0 && crossProduct2 < 0 && crossProduct3 < 0 && crossProduct4 < 0);
        }

        private static double CrossProduct(Point a, Point b, Point c)
        {
            double x1 = b.X - a.X;
            double y1 = b.Y - a.Y;
            double x2 = c.X - b.X;
            double y2 = c.Y - b.Y;

            return x1 * y2 - y1 * x2;
        }
    }
}
