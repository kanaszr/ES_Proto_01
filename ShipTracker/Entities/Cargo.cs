using System;
using System.Threading;
using ShipTracker.Events;

namespace ShipTracker.Entities
{
    public class Cargo
    {
        public string Name { get; internal set; }
        public bool HasBeenInCanada { get; set; }
        public bool IsLoaded { get; set; }

        public Cargo(string name)
        {
            Name = name;
        }

        public void HandleArrival(ArrivalEvent evt)
        {
            if (evt.Port.Country == Country.Canada)
                HasBeenInCanada = true;
        }

        public void HandleLoad(LoadEvent evt)
        {
            if(!IsLoaded)
                evt.Ship.HandleLoad(evt);
            else
            {
                throw new ArgumentException("Cargo is already loaded");
            }
        }
    }
}
