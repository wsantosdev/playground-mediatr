using MediatR;
using Playground.MediatR.Cafe.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.MediatR.Cafe.MediatR
{
    public class AvailableDosesRequestHandler : IRequestHandler<AvailableDosesRequest, AvailableDoses>
    {
        private readonly CoffeeDispenser _coffeeDispenser;
        private readonly LatteDispenser _latteDispenser;
        private readonly CappuccinoDispenser _cappuccinoDispenser;
        private readonly TeaDispenser _teaDispenser;

        public AvailableDosesRequestHandler(CoffeeDispenser coffeeDispenser,
                                            LatteDispenser latteDispenser,
                                            CappuccinoDispenser cappuccinoDispenser,
                                            TeaDispenser teaDispenser)
        {
            _coffeeDispenser = coffeeDispenser;
            _latteDispenser = latteDispenser;
            _cappuccinoDispenser = cappuccinoDispenser;
            _teaDispenser = teaDispenser;
        }

        public Task<AvailableDoses> Handle(AvailableDosesRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new AvailableDoses(_coffeeDispenser.AvailableDoses,
                                                      _latteDispenser.AvailableDoses,
                                                      _cappuccinoDispenser.AvailableDoses,
                                                      _teaDispenser.AvailableDoses));
        }
    }
}