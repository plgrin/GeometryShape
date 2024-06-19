# GeometryShape
## Project Overview
GeometryShapes is a C# application designed to perform various geometric computations and validations for shapes, specifically focusing on rectangles. The project involves creating and managing geometric shapes, reading parameters from a file, and validating input data. Additionally, it includes repository management, logging, and extensive unit testing to ensure the reliability of the application.

## Features
### Entity Classes:

Point: Represents a point in 2D space.

Rectangle: Represents a rectangle with necessary attributes.
### Action Classes:

Methods to calculate the area and perimeter of the rectangle.

Methods to determine if four points form a rectangle.

Methods to check if a quadrilateral is convex.

Methods to check if a rectangle is a square, rhombus, or trapezoid.
### Validation:

Validators for input data to ensure the correctness of shape parameters.

Validation of calculation results to ensure accuracy.

### File Reading:

Read parameters from a file with both correct and incorrect data handling.

Skips incorrect data and processes valid data.
### Logging:

Uses Serilog to log information to the console and a file.
### Repository Pattern:

Stores geometric shapes in a repository.

Methods to add, remove, and search shapes in the repository.

Sort and filter shapes based on various criteria.
### Warehouse:

Stores areas, volumes, and perimeters of shapes.

Updates values upon any change in shape parameters using Observer and Singleton patterns.
### Unit Testing:

Comprehensive unit tests using MSTest.

Tests are designed without unannotated methods, logging, branching statements, or multiple assertions.
## Usage
### Configuration:

Ensure Serilog is configured in Program.cs for logging.

Place the input data file in the appropriate directory.

### Running the Application:

Build the solution in your IDE (e.g., Visual Studio).

Run the application to process the data file and perform geometric computations.
### Logs:

Check the console and log files for information on processed shapes and any errors encountered.

## Requirements
.NET Core 3.1 or later

Visual Studio 2019 or later

## Conclusion
GeometryShapes is a comprehensive C# application designed for geometric shape management and computation. By following best practices and patterns, it ensures robust performance and maintainability. The inclusion of unit tests guarantees the reliability and correctness of the implemented functionalities.
