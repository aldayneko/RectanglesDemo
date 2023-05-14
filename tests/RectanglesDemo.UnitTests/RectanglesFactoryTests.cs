using RectanglesDemo.Domain;

namespace RectanglesDemo.UnitTests;

[TestClass]
public class RectanglesFactoryTests
{
    [TestMethod]
    public void RectanglesCountTest()
    {
        var factory = new RectangleFactory();
        var count = 23;
        var rectangles = factory.CreateRectangles(count);
        Assert.AreEqual(count, rectangles.Count());
    }

    [TestMethod]
    public void RectanglesCountZeroTest()
    {
        var factory = new RectangleFactory();
        var rectangles = factory.CreateRectangles(0);
        Assert.IsTrue(rectangles.Count() == 0);
    }

    [TestMethod]
    public void RectanglesCountNegativeTest()
    {
        var factory = new RectangleFactory();
        var rectangles = factory.CreateRectangles(-10);
        Assert.IsTrue(rectangles.Count() == 0);
    }

    [TestMethod]
    public void RectanglesAllValidTest()
    {
        var factory = new RectangleFactory();
        var rectangles = factory.CreateRectangles(10);
        Assert.IsTrue(rectangles.All(x => x.IsVaid()));
    }
}