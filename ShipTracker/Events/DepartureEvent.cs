using System;
using ShipTracker.Entities;

namespace ShipTracker.Events
{
    public class DepartureEvent:DomainEvent
    {
        private Ship _ship;
        private Port _port;

        public Port Port
        {
            get { return _port; }
        }

        public Ship Ship
        {
            get
            {
                return _ship;
            }
        }

        public DepartureEvent(DateTime occured, Ship ship)
            : base(occured)
        {
            _ship = ship;
        }

        public override void Process()
        {
            this.Ship.HandleDeparture(this);
        }
    }
}
