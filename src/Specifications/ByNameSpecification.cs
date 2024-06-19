using GeometricShape.Entities;

namespace GeometricShape.Specifications
{
    public class ByNameSpecification : ISpecification<Rectangle>
    {
        private readonly string _name;

        public ByNameSpecification(string name)
        {
            _name = name;
        }

        public bool IsSatisfiedBy(Rectangle entity)
        {
            return entity.Name == _name;
        }
    }
}
