using MediatR;
using Playground.MediatR.Cafe.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.MediatR.Cafe.MediatR
{
    public class LatteRequestHandler : DrinkRequestHandlerBase<LatteDispenser>,
                                       IRequestHandler<LatteRequest>
    {
        public LatteRequestHandler(IMediator mediator, LatteDispenser dispenser) : base(mediator, dispenser) { }

        Task<Unit> IRequestHandler<LatteRequest, Unit>.Handle(LatteRequest request, CancellationToken cancellationToken) =>
            Handle();
    }
}
