using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShipTracker.Entities;
using ShipTracker.Events;

namespace ShipTracker.Tests
{
    [TestClass]
    public class WhenUsingShip
    {
        private Ship _colomboExpress;
        private Ship _dusseldorfExpress;
        private EventAggregator _aggregator;
        private Port _sanFrancisco;
        private Port _toronto;
        private Port _mexico;
        private Cargo _cargo;

        [TestInitialize]
        public void SetUp()
        {
            _colomboExpress = new Ship("Colombo Express");
            _dusseldorfExpress = new Ship("Dusseldorf Express");
            _sanFrancisco = new Port("San Francisco",Country.USA);
            _toronto = new Port("Toronto",Country.Canada);
            _mexico = new Port("Mexico City",Country.Mexico);

            _aggregator = new EventAggregator();
            _cargo = new Cargo("Dildos");
            
        }

        [TestMethod]
        public void ArrivalEventSetsPort()
        {
            _aggregator.Process(new ArrivalEvent(new DateTime(2012, 12, 25), _colomboExpress, _sanFrancisco));
            Assert.AreEqual(_sanFrancisco, _colomboExpress.Port);
        }

        [TestMethod]
        public void DepartureEventSetsPortToAtSea()
        {
            _aggregator.Process(new DepartureEvent(new DateTime(2012, 12, 25), _colomboExpress));
            Assert.AreEqual(Port.At_Sea.Name, _colomboExpress.Port.Name);
        }

        [TestMethod]
        public void LoadEventAddsCargoOnShip()
        {
            _aggregator.Process(new LoadEvent(new DateTime(2012,12,25), _cargo,_colomboExpress));
            Assert.AreEqual(1, _colomboExpress.Cargo.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CargoCannotBeLoadedTwice()
        {
            _aggregator.Process(new LoadEvent(new DateTime(2012, 12, 25), _cargo, _colomboExpress));
            _aggregator.Process(new LoadEvent(new DateTime(2012, 12, 25), _cargo, _colomboExpress));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CargoCannotBeLoadedOnDifferentShips()
        {
            _aggregator.Process(new LoadEvent(new DateTime(2012, 12, 25), _cargo, _colomboExpress));
            _aggregator.Process(new LoadEvent(new DateTime(2012, 12, 25), _cargo, _dusseldorfExpress));
        }

        [TestMethod]
        public void ArrivalChecksWhetherPortCountryIsCanada()
        {
            _aggregator.Process(new ArrivalEvent(new DateTime(2012, 12, 25), _colomboExpress, _sanFrancisco));
            _aggregator.Process(new LoadEvent(new DateTime(2012, 12, 25), _cargo, _colomboExpress));
            _aggregator.Process(new ArrivalEvent(new DateTime(2012, 12, 25), _colomboExpress, _mexico));
            _aggregator.Process(new ArrivalEvent(new DateTime(2012, 12, 25), _colomboExpress, _toronto));
            _aggregator.Process(new ArrivalEvent(new DateTime(2012, 12, 25), _colomboExpress, _sanFrancisco));

            Assert.IsTrue(_cargo.HasBeenInCanada);
        }

    }


}
