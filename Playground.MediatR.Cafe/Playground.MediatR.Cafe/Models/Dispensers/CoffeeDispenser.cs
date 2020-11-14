namespace Playground.MediatR.Cafe.Models
{
    public class CoffeeDispenser : AbstractDispenser
    {
        protected override Drink DispenseCore() =>
            new Coffee();
    }
}
