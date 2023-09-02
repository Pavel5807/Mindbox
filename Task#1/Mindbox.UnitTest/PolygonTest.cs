using System.Numerics;

namespace Mindbox.UnitTest;

public class PolygonTest
{
    private readonly double _tolerance = 0.1e-6;

    [Fact]
    public void GetSquare_ShapeIsRectangle_ReturnsSquare()
    {
        var points = new Vector2[]{
            new(0,0),
            new(1,0),
            new(1,1),
            new(0,1),
        };
        var expectedSquare = 1;
        var shape = new Polygon(points);

        var actualSquare = shape.CalculateSquare();

        Assert.Equal(expectedSquare, actualSquare, _tolerance);
    }

    [Fact]
    public void Ctor_ShapeIsPoint_ThrowsInvalidDataException()
    {
        var point = new Vector2(0, 0);

        Assert.Throws<InvalidDataException>(() => { var shape = new Polygon(point); });
    }
}
