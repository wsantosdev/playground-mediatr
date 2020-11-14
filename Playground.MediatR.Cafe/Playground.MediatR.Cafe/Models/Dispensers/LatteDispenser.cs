namespace Playground.MediatR.Cafe.Models
{
    public class LatteDispenser : AbstractDispenser
    {
        protected override Drink DispenseCore() =>
            new Latte();
    }
}
