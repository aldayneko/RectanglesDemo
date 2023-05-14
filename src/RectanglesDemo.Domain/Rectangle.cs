namespace RectanglesDemo.Domain;

public class Rectangle
{
    public int Id { get; set; }

    public double X1 { get; set; }
    public double Y1 { get; set; }

    public double X2 { get; set; }
    public double Y2 { get; set; }

    public double X3 { get; set; }
    public double Y3 { get; set; }

    public double X4 { get; set; }
    public double Y4 { get; set; }

    public Rectangle()
    {

    }

    public Rectangle(Point a, Point b, Point c, Point d)
    {
        X1 = a.X;
        Y1 = a.Y;

        X2 = b.X;
        Y2 = b.Y;

        X3 = c.X;
        Y3 = c.Y;

        X4 = d.X;
        Y4 = d.Y;
    }

    public bool IsVaid()
    {
        return ((Y1 == Y2 && X1 != X2) ||
                (Y1 == Y3 && X1 != X3) ||
                (Y1 == Y4 && X1 != X4)) &&
               ((X1 == X2 && Y1 != Y2) ||
                (X1 == X3 && Y1 != Y3) ||
                (X1 == X4 && Y1 != Y4));
    }
}