using MediatR;

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
    public Task Handle(PopulateRectanglesCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
