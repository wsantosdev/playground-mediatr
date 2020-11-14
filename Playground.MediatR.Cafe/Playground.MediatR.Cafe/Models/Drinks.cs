namespace Playground.MediatR.Cafe.Models
{
    public record Drink(string Name);

    public record Coffee : Drink { public Coffee() : base("Coffee") {} }
    public record Latte : Drink { public Latte() : base("Latte") {} }
    public record Cappuccino : Drink { public Cappuccino() : base("Cappuccino") {} }
    public record Tea : Drink { public Tea() : base("Tea") {} }
}