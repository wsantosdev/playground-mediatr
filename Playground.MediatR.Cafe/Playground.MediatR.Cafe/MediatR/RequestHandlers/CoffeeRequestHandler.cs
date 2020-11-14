using MediatR;
using Playground.MediatR.Cafe.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.MediatR.Cafe.MediatR
{
    public class CoffeeRequestHandler : DrinkRequestHandlerBase<CoffeeDispenser>,
                                        IRequestHandler<CoffeeRequest>
    {
        public CoffeeRequestHandler(IMediator mediator, CoffeeDispenser dispenser) : base(mediator, dispenser) { }

        Task<Unit> IRequestHandler<CoffeeRequest, Unit>.Handle(CoffeeRequest request, CancellationToken cancellationToken) =>
            Handle();
    }
}