using MediatR;
using Playground.MediatR.Cafe.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.MediatR.Cafe.MediatR
{
    public class CappuccinoRequestHandler : DrinkRequestHandlerBase<CappuccinoDispenser>,
                                            IRequestHandler<CappuccinoRequest>
    {
        public CappuccinoRequestHandler(IMediator mediator, CappuccinoDispenser dispenser)
            : base(mediator, dispenser) { }

        Task<Unit> IRequestHandler<CappuccinoRequest, Unit>.Handle(CappuccinoRequest request, CancellationToken cancellationToken) =>
            Handle();
    }
}
