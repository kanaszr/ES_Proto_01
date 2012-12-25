using System;
using ShipTracker.Entities;

namespace ShipTracker.Events
{
    public class ArrivalEvent:DomainEvent
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

        public ArrivalEvent(DateTime occured, Ship ship, Port port):base(occured)
        {
            _ship = ship;
            _port = port;
        }

        public override void Process()
        {
            this.Ship.HandleArrival(this);
        }
    }
}
