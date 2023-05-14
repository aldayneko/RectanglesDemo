using MediatR;
using RectanglesDemo.Application.Common;
using RectanglesDemo.Domain;

namespace RectanglesDemo.Application.Commands;

public class PopulateRectanglesCommand : IRequest
{
    public readonly int Count;

    public PopulateRectanglesCommand(int count)
    {
        Count = count;
    }
}

public class PopulateRectanglesCommandHandler : IRequestHandler<PopulateRectanglesCommand>
{
    private readonly IRectanglesStorage _rectanglesStorage;

    public PopulateRectanglesCommandHandler(IRectanglesStorage rectanglesStorage)
    {
        _rectanglesStorage = rectanglesStorage;
    }

    public async Task Handle(PopulateRectanglesCommand request, CancellationToken cancellationToken)
    {
        await _rectanglesStorage.CheckAndCreateStorage();

        var rectanglesFactory = new RectangleFactory();
        var rectangles = rectanglesFactory.CreateRectangles(request.Count);
        await _rectanglesStorage.Save(rectangles);
    }
}
