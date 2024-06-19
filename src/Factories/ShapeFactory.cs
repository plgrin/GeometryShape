using GeometricShape.Entities;

namespace GeometricShape.Factories
{
    public abstract class ShapeFactory
    {
        public abstract GeometricShape.Entities.Point CreatePoint(double x, double y);
        public abstract Rectangle CreateRectangle(string name, List<GeometricShape.Entities.Point> points);
    }

    public class ConcreteShapeFactory : ShapeFactory
    {
        public override GeometricShape.Entities.Point CreatePoint(double x, double y)
        {
            var pointFactory = new PointFactory();
            return pointFactory.Create(x, y);
        }

        public override Rectangle CreateRectangle(string name, List<GeometricShape.Entities.Point> points)
        {
            var rectangleFactory = new RectangleFactory();
            return rectangleFactory.Create(name, points);
        }
    }
}
