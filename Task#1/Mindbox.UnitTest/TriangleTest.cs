namespace Mindbox.UnitTest;

public class TriangleTest
{
    private readonly double _tolerance = 0.1e-5;

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(4, 5, 6.403124)]
    public void IsRectangular_TriangleIsRectangular_ReturnsTrue(double a, double b, double c)
    {
        var shape = new Triangle(a, b, c);

        var isRectangular = shape.IsRectangular();

        Assert.True(isRectangular);
    }

    [Theory]
    [InlineData(3, 3, 3)]
    public void IsRectangular_TriangleIsNotRectangular_ReturnsFalse(double a, double b, double c)
    {
        var shape = new Triangle(a, b, c);

        var isRectangular = shape.IsRectangular();

        Assert.False(isRectangular);
    }

    [Theory]
    [InlineData(3, 3, 3, 3.897114)]
    [InlineData(3, 4, 5, 6)]
    public void GetSquare_ValideTriangle_ReturnsSquare(double a, double b, double c, double expectedSquare)
    {
        var shape = new Triangle(a, b, c);

        var actualSquare = shape.CalculateSquare();

        Assert.Equal(expectedSquare, actualSquare, _tolerance);
    }

    [Fact]
    public void Ctor_InvalidTriangleSide_ThrowsInvalidDataException()
    {
        var invalidSide = 0;
        var b = 1;
        var c = 2;

        Assert.Throws<InvalidDataException>(() => { var shape = new Triangle(invalidSide, b, c); });
    }
}