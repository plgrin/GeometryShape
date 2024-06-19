using System;
using GeometricShape.Entities;

namespace GeometricShape.Specifications
{
    public class ByIdSpecification : ISpecification<Rectangle>
    {
        private readonly Guid _id;

        public ByIdSpecification(Guid id)
        {
            _id = id;
        }

        public bool IsSatisfiedBy(Rectangle entity)
        {
            return entity.Id == _id;
        }
    }
}
