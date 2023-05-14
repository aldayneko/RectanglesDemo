using MediatR;
using RectanglesDemo.Application.Common;

namespace RectanglesDemo.Application.Commands;
public class ClearRectanglesCommand : IRequest
{
    public ClearRectanglesCommand()
    {
    }
}

public class ClearRectanglesCommandHandler : IRequestHandler<ClearRectanglesCommand>
{
    private readonly IRectanglesStorage _rectanglesStorage;

    public ClearRectanglesCommandHandler(IRectanglesStorage rectanglesStorage)
    {
        _rectanglesStorage = rectanglesStorage;
    }

    public Task Handle(ClearRectanglesCommand request, CancellationToken cancellationToken)
    {
        return _rectanglesStorage.RemoveAllRectangles();
    }
}
