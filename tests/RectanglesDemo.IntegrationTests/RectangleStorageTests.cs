using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RectanglesDemo.Application.Common;
using RectanglesDemo.Domain;
using RectanglesDemo.Infrastructure;

namespace RectanglesDemo.IntegrationTests;

[TestClass]
public class RectangleStorageTests
{
    protected readonly IRectanglesStorage rectanglesStorage;

    public RectangleStorageTests()
    {
        var configurations = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var connectionString = configurations["RectanglesDBConnectionString"];
        rectanglesStorage = new RectanglesStorage(new SqlConnection(connectionString));
    }

    [TestMethod]
    public async Task CheckAndCreateStorageTest()
    {
        await rectanglesStorage.CheckAndCreateStorage();
    }

    [TestMethod]
    public async Task RemoveAllRectanglesTest()
    {
        await rectanglesStorage.RemoveAllRectangles();
    }

    [TestMethod]
    public async Task SaveTest()
    {
        var factory = new RectangleFactory();
        var rectangles = factory.CreateRectangles(10);
        await rectanglesStorage.Save(rectangles);
    }

    [TestMethod]
    public async Task GetRectanglesWithPointTest()
    {
        await rectanglesStorage.GetRectanglesWithPoint(new Point(1,1), 0, 20);
    }

    [TestMethod]
    public async Task GetCountRectanglesWithPointTest()
    {
        await rectanglesStorage.GetCountRectanglesWithPoint(new Point(1, 1));
    }
}