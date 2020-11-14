using System;

namespace Playground.MediatR.Cafe.Models
{
    public abstract class AbstractDispenser
    {
        public int AvailableDoses { get; private set; } = 10;

        public Drink Dispense()
        {
            if (AvailableDoses <= 0)
                throw new InvalidOperationException("There is no available doses to dispense.");

            AvailableDoses--;

            return DispenseCore();
        }

        protected abstract Drink DispenseCore();
    }
}
