# Chili

A lightweight hexagonal grid library for C#.

Chili provides axial hex coordinates and common grid operations such as neighbor lookup, coordinate rotation, and 2D position conversion.

## Features

* Axial coordinate representation (`HexCoordinates`)
* Pointy-top hex grid implementation
* Neighbor coordinate lookup
* Hex coordinate rotation
* Conversion from hex coordinates to 2D positions
* No external dependencies

## Example

```csharp
using Chili;

IHexGrid grid = new PointyTopHexGrid();

var center = new HexCoordinates(0, 0);

var neighbors = grid.GetNeighbors(center);

foreach (var neighbor in neighbors)
{
    Console.WriteLine(neighbor);
}
```

Output:

```text
(0, 1)
(1, 0)
(1, -1)
(0, -1)
(-1, 0)
(-1, 1)
```

## Coordinate Rotation

Rotate coordinates around the origin.

```csharp
var coord = new HexCoordinates(1, 0);

var rotated = grid.Rotate(coord, 1);
```

Positive values rotate clockwise in 60° steps.

## Coordinate Conversion

Convert a hex coordinate to a 2D position.

```csharp
var point = grid.ToPoint(
    new HexCoordinates(2, 1),
    radius: 32f);
```

## Distance

```csharp
int distance = HexCoordinates.Distance(a, b);
```

## License

zlib/libpng License
