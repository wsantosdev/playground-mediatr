using MediatR;
using Playground.MediatR.Cafe.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.MediatR.Cafe.MediatR
{
    public class TeaRequestHandler : DrinkRequestHandlerBase<TeaDispenser>,
                                     IRequestHandler<TeaRequest>
    {
        public TeaRequestHandler(IMediator mediator, TeaDispenser dispenser) : base(mediator, dispenser) { }

        Task<Unit> IRequestHandler<TeaRequest, Unit>.Handle(TeaRequest request, CancellationToken cancellationToken) =>
            Handle();
    }
}
