using MediatR;
using RectanglesDemo.Application.Common;
using RectanglesDemo.Domain;

namespace RectanglesDemo.Application.Queries;

public record SearchResult(Point Point, List<Rectangle> Data, int Total);

public class SearchRectanglesQuery : IRequest<List<SearchResult>>
{
    public readonly Point[] Points;

    public readonly int Page;

    public readonly int PageSize;

    public SearchRectanglesQuery(Point[] points, int page = 0, int pageSize = 50)
    {
        Points = points;
        Page = page;
        PageSize = pageSize;
    }
}

public class SearchRectanglesQueryHandler : IRequestHandler<SearchRectanglesQuery, List<SearchResult>>
{
    private readonly IRectanglesStorage _rectanglesStorage;

    public SearchRectanglesQueryHandler(IRectanglesStorage rectanglesStorage)
    {
        _rectanglesStorage = rectanglesStorage;
    }

    public async Task<List<SearchResult>> Handle(SearchRectanglesQuery request, CancellationToken cancellationToken)
    {
        var result = new List<SearchResult>();
        
        foreach (var point in request.Points)
        {
            var rectangles = await _rectanglesStorage.GetRectanglesWithPoint(point, request.Page, request.PageSize);
            var total = await _rectanglesStorage.GetCountRectanglesWithPoint(point);
            result.Add(new SearchResult(point, rectangles.ToList(), total));
        }

        return result;
    }
}
