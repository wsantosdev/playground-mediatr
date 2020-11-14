using MediatR;
using Microsoft.AspNetCore.SignalR;
using Playground.MediatR.Cafe.MediatR;
using Playground.MediatR.Cafe.Models;
using System;
using System.Threading.Tasks;

namespace Playground.MediatR.Cafe.Hubs
{
    public class DrinkMachineHub : Hub<IDrinkMachineHub>
    {
        private readonly IMediator _mediator;

        public DrinkMachineHub(IMediator mediator) =>
            _mediator = mediator;

        public async Task GetAvailableDoses() =>
            await Clients.All.Ready(await _mediator.Send(new AvailableDosesRequest()));

        public async Task RequestDrink(int machineSlot)
        {
            switch((MachineSlot)machineSlot)
            {
                case MachineSlot.Coffee:
                    await _mediator.Send(new CoffeeRequest());
                    break;
                case MachineSlot.Latte:
                    await _mediator.Send(new LatteRequest());
                    break;
                case MachineSlot.Cappuccino:
                    await _mediator.Send(new CappuccinoRequest());
                    break;
                case MachineSlot.Tea:
                    await _mediator.Send(new TeaRequest());
                    break;
                default:
                    throw new ArgumentException("Invalid option.");
            }
        }
    }
}