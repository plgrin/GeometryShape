using System;
using System.Collections.Generic;
using System.Linq;
using GeometricShape.Observers;

namespace GeometricShape.Entities
{
    public class Rectangle : IObservable
    {
        public Guid Id { get; }
        public string Name { get; }
        public List<Point> Points { get; }

        private readonly List<IObserver> _observers = new List<IObserver>();

        public Rectangle(string name, List<Point> points)
        {
            if (points.Count != 4)
            {
                throw new ArgumentException("Rectangle must have exactly 4 points.");
            }

            Id = Guid.NewGuid();
            Name = name;
            Points = points;
            Attach(ShapeWarehouse.Instance());
            Notify();  // Уведомляем наблюдателей сразу после создания
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void UpdatePoints(List<Point> newPoints)
        {
            if (newPoints.Count != 4)
            {
                throw new ArgumentException("Rectangle must have exactly 4 points.");
            }

            Points.Clear();
            Points.AddRange(newPoints);
            Notify();
        }

        // Переопределение методов ToString, Equals и GetHashCode
        public override string ToString()
        {
            return $"Rectangle(Name: {Name}, Points: {string.Join(", ", Points)})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Rectangle other = (Rectangle)obj;
            return Id == other.Id && Name == other.Name && Points.SequenceEqual(other.Points);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Points);
        }
    }
}
