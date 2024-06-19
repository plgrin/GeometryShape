using System;
using System.Collections.Generic;
using GeometricShape.Actions;
using GeometricShape.Entities;

namespace GeometricShape.Observers
{
    public class ShapeWarehouse : IObserver
    {
        private static ShapeWarehouse _instance;
        private Dictionary<Guid, (double Area, double Perimeter)> _storage;

        private ShapeWarehouse()
        {
            _storage = new Dictionary<Guid, (double Area, double Perimeter)>();
        }

        public static ShapeWarehouse Instance()
        {
            if (_instance == null)
            {
                _instance = new ShapeWarehouse();
            }
            return _instance;
        }

        public void Update(Rectangle rectangle)
        {
            _storage[rectangle.Id] = (RectangleActions.CalculateArea(rectangle), RectangleActions.CalculatePerimeter(rectangle));
        }

        public (double Area, double Perimeter) GetMetrics(Guid id)
        {
            if (_storage.ContainsKey(id))
            {
                return _storage[id];
            }
            throw new KeyNotFoundException("Metrics not found for the given ID");
        }
    }
}
