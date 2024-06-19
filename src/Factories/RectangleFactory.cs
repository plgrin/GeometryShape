using System.Collections.Generic;
using GeometricShape.Entities;

namespace GeometricShape.Factories
{
    public class RectangleFactory : IFactory<Rectangle>
    {
        public Rectangle Create(params object[] args)
        {
            string name = (string)args[0];
            List<GeometricShape.Entities.Point> points = (List<GeometricShape.Entities.Point>)args[1];
            return new Rectangle(name, points);
        }
    }
}
