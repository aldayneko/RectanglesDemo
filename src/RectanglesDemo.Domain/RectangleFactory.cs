namespace RectanglesDemo.Domain;

public class RectangleFactory
{
    private const int MAX_COORDINATE = 1000;
    private const int MIN_COORDINATE = -1000;

    private Random _random = new Random((int)DateTime.Now.Ticks);

    public IEnumerable<Rectangle> CreateRectangles(int n)
    {
        for (int i = 0; i < n; i++)
        {
            var height = GetRandomSize();
            var width = GetRandomSize();

            var a = GetRandomPoint();
            var b = new Point(a.X, a.Y + height);
            var c = new Point(b.X + width, b.Y);
            var d = new Point(a.X + width, a.Y);

            yield return new Rectangle(a, b, c, d);
        }
    }

    private int GetRandomSize()
    {
        return _random.Next(1, MAX_COORDINATE);
    }

    private Point GetRandomPoint()
    {
        var x1 = _random.Next(MIN_COORDINATE, MAX_COORDINATE);
        var y1 = _random.Next(MIN_COORDINATE, MAX_COORDINATE);

        return new Point(x1, y1);
    }
}