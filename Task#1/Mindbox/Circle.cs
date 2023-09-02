namespace Mindbox;

public class Circle : Shape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (radius < 0)
        {
            throw new InvalidDataException();
        }

        _radius = radius;
    }

    public override double CalculateSquare()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}
