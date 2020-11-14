using MediatR;
using Microsoft.AspNetCore.SignalR;
using Playground.MediatR.Cafe.Hubs;
using Playground.MediatR.Cafe.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.MediatR.Cafe.MediatR
{
    public record DrinkDispensed(Drink Drink, int RemainingDoses) : INotification;

    public class DrinkDispensedEventHandler : INotificationHandler<DrinkDispensed>
    {
        private readonly IHubContext<DrinkMachineHub, IDrinkMachineHub> _hubContext;

        public DrinkDispensedEventHandler(IHubContext<DrinkMachineHub, IDrinkMachineHub> hubContext) =>
            _hubContext = hubContext;

        public async Task Handle(DrinkDispensed notification, CancellationToken cancellationToken) =>
            await _hubContext.Clients.All.Serve(notification.Drink.Name, notification.RemainingDoses);
    }
}