using RectanglesDemo.Domain;

namespace RectanglesDemo.UnitTests;

[TestClass]
public class RectangleTests
{
    [TestMethod]
    public void ZeroRectangleTest()
    {
        var a = new Point(0, 0);
        var b = new Point(0, 0);
        var c = new Point(0, 0);
        var d = new Point(0, 0);

        var rectangle = new Rectangle(a, b, c, d);

        Assert.IsFalse(rectangle.IsVaid());
    }

    [TestMethod]
    public void ValidRectangleTest()
    {
        var a = new Point(1, 1);
        var b = new Point(1, 2);
        var c = new Point(4, 2);
        var d = new Point(4, 1);

        var rectangle = new Rectangle(a, b, c, d);

        Assert.IsTrue(rectangle.IsVaid());
    }

    [TestMethod]
    public void InvalidRectangleTest()
    {
        var a = new Point(1, 1);
        var b = new Point(1, 2);
        var c = new Point(4, 2);
        var d = new Point(4, 10);

        var rectangle = new Rectangle(a, b, c, d);

        Assert.IsFalse(rectangle.IsVaid());
    }
}