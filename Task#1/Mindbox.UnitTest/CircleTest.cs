namespace Mindbox.UnitTest;

public class CircleTest
{
    private readonly double _tolerance = 0.1e-5;

    [Fact]
    public void Ctor_InvalidRadius_ThrowsInvalidDataException()
    {
        var radius = -1;

        Assert.Throws<InvalidDataException>(() => { var shape = new Circle(radius); });
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 3.141592)]
    public void GetSquare_ValidRadius_ReturnsSquare(double radius, double expectedSquare)
    {
        var shape = new Circle(radius);

        var actualSquare = shape.CalculateSquare();

        Assert.Equal(expectedSquare, actualSquare, _tolerance);
    }
}
