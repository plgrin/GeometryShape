using GeometricShape.Entities;
using System;

namespace GeometricShape.Factories
{
    public class PointFactory : IFactory<GeometricShape.Entities.Point>
    {
        public Entities.Point Create(params object[] args)
        {
            double x = Convert.ToDouble(args[0]);
            double y = Convert.ToDouble(args[1]);
            return new GeometricShape.Entities.Point(x, y);
        }
    }
}

