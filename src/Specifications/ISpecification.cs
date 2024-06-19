namespace GeometricShape.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
