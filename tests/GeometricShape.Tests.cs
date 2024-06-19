using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GeometricShape.Entities;
using GeometricShape.Actions;
using GeometricShape.Observers;

namespace GeometricShape.Tests
{
    [TestClass]
    public class RectangleTests
    {
        private static readonly List<GeometricShape.Entities.Point> ValidSquarePoints = new List<GeometricShape.Entities.Point>
        {
            new GeometricShape.Entities.Point(0, 0),
            new GeometricShape.Entities.Point(3, 0),
            new GeometricShape.Entities.Point(3, 3),
            new GeometricShape.Entities.Point(0, 3)
        };

        private static readonly List<GeometricShape.Entities.Point> ValidRectanglePoints = new List<GeometricShape.Entities.Point>
        {
            new GeometricShape.Entities.Point(0, 0),
            new GeometricShape.Entities.Point(4, 0),
            new GeometricShape.Entities.Point(4, 3),
            new GeometricShape.Entities.Point(0, 3)
        };

        [TestMethod]
        public void TestCalculateArea()
        {
            // Given
            var rectangle = new Rectangle("TestRectangle", ValidRectanglePoints);

            // When
            double area = RectangleActions.CalculateArea(rectangle);

            // Then
            Assert.AreEqual(12, area);
        }

        [TestMethod]
        public void TestCalculatePerimeter()
        {
            // Given
            var rectangle = new Rectangle("TestRectangle", ValidRectanglePoints);

            // When
            double perimeter = RectangleActions.CalculatePerimeter(rectangle);

            // Then
            Assert.AreEqual(14, perimeter);
        }

        [TestMethod]
        public void TestIsSquare()
        {
            // Given
            var rectangle = new Rectangle("TestSquare", ValidSquarePoints);

            // When
            bool isSquare = RectangleActions.IsSquare(rectangle);

            // Then
            Assert.IsTrue(isSquare);
        }

        [TestMethod]
        public void TestIsNotSquare()
        {
            // Given
            var rectangle = new Rectangle("TestRectangle", ValidRectanglePoints);

            // When
            bool isSquare = RectangleActions.IsSquare(rectangle);

            // Then
            Assert.IsFalse(isSquare);
        }

        [TestMethod]
        public void TestWarehouseUpdates()
        {
            // Given
            var rectangle = new Rectangle("TestRectangle", ValidRectanglePoints);
            var warehouse = ShapeWarehouse.Instance();

            // When
            rectangle.UpdatePoints(new List<GeometricShape.Entities.Point>
            {
                new GeometricShape.Entities.Point(1, 1),
                new GeometricShape.Entities.Point(5, 1),
                new GeometricShape.Entities.Point(5, 4),
                new GeometricShape.Entities.Point(1, 4)
            });

            // Then
            var metrics = warehouse.GetMetrics(rectangle.Id);
            Assert.AreEqual(12, metrics.Area);
            Assert.AreEqual(14, metrics.Perimeter);
        }
    }
}
