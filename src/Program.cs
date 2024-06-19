using System;
using System.Collections.Generic;
using GeometricShape.Entities;
using GeometricShape.Utilities;
using GeometricShape.Repositories;
using GeometricShape.Specifications;
using GeometricShape.Observers;
using Serilog;
using Serilog.Events;
using GeometricShape.Comparators;

namespace GeometricShape
{
    class Program
    {
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application started.");

            try
            {
                // Загрузка прямоугольников из файла
                var rectangles = DataLoader.LoadRectangles("Data/rectangles.txt");
                var repository = new ShapeRepository();

                // Добавление прямоугольников в репозиторий
                foreach (var rectangle in rectangles)
                {
                    repository.Add(rectangle);
                    Log.Information($"Added rectangle: {rectangle}");
                }

                // Получение экземпляра ShapeWarehouse
                var warehouse = ShapeWarehouse.Instance();

                // Просмотр метрик для всех прямоугольников в репозитории
                foreach (var rectangle in rectangles)
                {
                    var metrics = warehouse.GetMetrics(rectangle.Id);
                    Log.Information($"Rectangle {rectangle.Name} - Area: {metrics.Area}, Perimeter: {metrics.Perimeter}");
                }

                // Пример использования спецификаций для поиска
                // Поиск прямоугольника по ID
                var idSpec = new ByIdSpecification(rectangles[0].Id);
                var foundById = repository.Find(idSpec);
                Log.Information($"Found by ID: {string.Join(", ", foundById)}");

                // Поиск прямоугольников по имени
                var nameSpec = new ByNameSpecification("Rectangle1");
                var foundByName = repository.Find(nameSpec);
                Log.Information($"Found by Name: {string.Join(", ", foundByName)}");

                // Поиск прямоугольников по координатам
                var coordSpec = new ByCoordinateSpecification();
                var foundByCoord = repository.Find(coordSpec);
                Log.Information($"Found by Coordinates: {string.Join(", ", foundByCoord)}");

                // Сортировка прямоугольников по имени
                rectangles.Sort(new ShapeComparator());
                Log.Information($"Sorted rectangles by name: {string.Join(", ", rectangles)}");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing rectangles.");
            }

            Log.Information("Application ended.");
        }
    }
}
