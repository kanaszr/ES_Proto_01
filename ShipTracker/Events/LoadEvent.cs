using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShipTracker.Entities;

namespace ShipTracker.Events
{
    public class LoadEvent:DomainEvent
    {
        private Cargo _cargo;
        private Ship _ship;

        public Cargo Cargo
        {
            get { return _cargo; }
        }

        public Ship Ship
        {
            get { return _ship; }
        }

        public LoadEvent(DateTime occured, Cargo cargo, Ship ship):base(occured)
        {
            _cargo = cargo;
            _ship = ship;
        }

        public override void Process()
        {
            this.Cargo.HandleLoad(this);
        }
    }
}
