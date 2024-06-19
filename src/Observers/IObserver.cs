using GeometricShape.Entities;

namespace GeometricShape.Observers
{
    public interface IObserver
    {
        void Update(Rectangle rectangle);
    }
}
