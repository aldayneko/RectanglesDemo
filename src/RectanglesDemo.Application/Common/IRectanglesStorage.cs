using RectanglesDemo.Domain;

namespace RectanglesDemo.Application.Common;

public interface IRectanglesStorage
{
    Task CheckAndCreateStorage();
    Task Save(IEnumerable<Rectangle> rectangles);
    Task<List<Rectangle>> GetRectanglesWithPoint(int x, int y);
}