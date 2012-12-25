using System;

namespace ShipTracker.Events
{
    public abstract class DomainEvent
    {
        DateTime _recorded, _occurred;

        public DomainEvent(DateTime occured)
        {
            _occurred = occured;
            _recorded = DateTime.Now;
        }

        public abstract void Process();
    }
}
