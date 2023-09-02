namespace Mindbox;

public class Triangle : Shape
{
    private List<double> _sides;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new InvalidDataException();
        }

        _sides = new()
        {
            sideA,
            sideB,
            sideC
        };
        _sides.Sort();
    }

    public override double CalculateSquare()
    {
        var p = _sides.Sum() / 2;
        var result = p;
        foreach (var side in _sides)
        {
            result *= p - side;
        }

        return Math.Sqrt(result);
    }

    public bool IsRectangular(double tolerance = 0.1e-4)
    {
        return Math.Abs(Math.Pow(_sides[2], 2) - Math.Pow(_sides[0], 2) - Math.Pow(_sides[1], 2)) <= tolerance;
    }
}
