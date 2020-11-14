using Playground.MediatR.Cafe.Models;
using System.Threading.Tasks;

namespace Playground.MediatR.Cafe.Hubs
{
    public interface IDrinkMachineHub
    {
        Task Ready(AvailableDoses availableDoses);
        Task Serve(string drinkName, int remainingDoses);
    }
}