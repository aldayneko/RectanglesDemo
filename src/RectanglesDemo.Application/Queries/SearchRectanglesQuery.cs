using MediatR;
using RectanglesDemo.Domain;

namespace RectanglesDemo.Application.Queries;

public class SearchRectanglesQuery : IRequest<List<Rectangle>>
{
    public readonly Point[] Points;

    public SearchRectanglesQuery(Point[] points)
    {
        Points = points;
    }
}

public class SearchRectanglesQueryHandler : IRequestHandler<SearchRectanglesQuery, List<Rectangle>>
{
    public Task<List<Rectangle>> Handle(SearchRectanglesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
