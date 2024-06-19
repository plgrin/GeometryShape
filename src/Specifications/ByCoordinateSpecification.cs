using GeometricShape.Entities;
using System.Linq;

namespace GeometricShape.Specifications
{
    public class ByCoordinateSpecification : ISpecification<Rectangle>
    {
        public bool IsSatisfiedBy(Rectangle entity)
        {
            return entity.Points.All(p => p.X > 0 && p.Y > 0);
        }
    }
}
