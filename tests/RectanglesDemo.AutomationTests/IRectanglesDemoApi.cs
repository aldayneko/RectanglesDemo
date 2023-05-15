using RectanglesDemo.AutomationTests.Models;
using Refit;

namespace RectanglesDemo.AutomationTests;

public interface IRectanglesDemoApi
{
    [Post("/RectanglesSearch/Search")]
    [Headers("Authorization: Basic", "Content-Type: application/json; charset=UTF-8")]
    Task<ApiResponse<IEnumerable<List<SearchResult>>>> Search(Point[] points);
}