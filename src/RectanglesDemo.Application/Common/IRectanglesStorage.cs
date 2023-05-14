using RectanglesDemo.Domain;

namespace RectanglesDemo.Application.Common;

public interface IRectanglesStorage
{
    Task CheckAndCreateStorage();
    Task RemoveAllRectangles();
    Task Save(IEnumerable<Rectangle> rectangles);
    Task<IEnumerable<Rectangle>> GetRectanglesWithPoint(Point point, int page, int pageSize);
    Task<int> GetCountRectanglesWithPoint(Point point);
}