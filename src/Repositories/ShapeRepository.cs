using System;
using System.Collections.Generic;
using System.Linq;
using GeometricShape.Entities;
using GeometricShape.Specifications;

namespace GeometricShape.Repositories
{
    public class ShapeRepository : IRepository<Rectangle>
    {
        private readonly List<Rectangle> _shapes = new List<Rectangle>();

        public void Add(Rectangle entity)
        {
            _shapes.Add(entity);
        }

        public void Remove(Rectangle entity)
        {
            _shapes.Remove(entity);
        }

        public Rectangle GetById(Guid id)
        {
            return _shapes.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Rectangle> GetAll()
        {
            return _shapes;
        }

        public IEnumerable<Rectangle> Find(ISpecification<Rectangle> specification)
        {
            return _shapes.Where(specification.IsSatisfiedBy);
        }
    }
}
