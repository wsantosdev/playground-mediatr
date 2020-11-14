namespace Playground.MediatR.Cafe.Models
{
    public class TeaDispenser : AbstractDispenser
    {
        protected override Drink DispenseCore() =>
            new Tea();
    }
}
