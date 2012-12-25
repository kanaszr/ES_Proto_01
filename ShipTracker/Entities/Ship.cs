using System;
using System.Collections.Generic;
using ShipTracker.Events;

namespace ShipTracker.Entities
{
    public class Ship
    {
        public string Name { get; set; }
        private Port _port;
        public Port Port { get { return _port; } }
        public List<Cargo> Cargo;

        public Ship(string name)
        {
            Name = name;
            Cargo = new List<Cargo>();
        }

        public void HandleArrival(ArrivalEvent evt)
        {
            _port = evt.Port;
            foreach (var cargo in Cargo)
            {
                cargo.HandleArrival(evt);
            }
        }

        public void HandleDeparture(DepartureEvent evt)
        {
            _port = Port.At_Sea;
        }

        public void HandleLoad(LoadEvent evt)
        {
            Cargo.Add(evt.Cargo);
            evt.Cargo.IsLoaded = true;
        }
    }
}
