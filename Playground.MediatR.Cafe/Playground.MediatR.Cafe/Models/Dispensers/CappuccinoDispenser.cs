namespace Playground.MediatR.Cafe.Models
{
    public class CappuccinoDispenser : AbstractDispenser
    {
        protected override Drink DispenseCore() =>
            new Cappuccino();
    }
}
