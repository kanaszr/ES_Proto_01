using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShipTracker.Events;

namespace ShipTracker
{
    public class EventAggregator
    {
        private List<DomainEvent> _log;

        public EventAggregator()
        {
            _log = new List<DomainEvent>();
        }

        public void Process(DomainEvent evt)
        {
            _log.Add(evt);
            evt.Process();
        }

    }
}
