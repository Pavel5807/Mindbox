using System.Numerics;

namespace Mindbox;

public class Polygon : Shape
{
    private Vector2[] _points;

    public Polygon(params Vector2[] points)
    {
        if (points.Length < 3)
        {
            throw new InvalidDataException();
        }

        _points = points;
    }

    public override double CalculateSquare()
    {
        double tmp = _points[^1].X * _points[0].Y - _points[0].X * _points[^1].Y;
        for (var i = 0; i < _points.Length - 1; i++)
        {
            tmp += _points[i].X * _points[i + 1].Y;
            tmp -= _points[i + 1].X * _points[i].Y;
        }

        return Math.Abs(tmp) / 2;
    }
}