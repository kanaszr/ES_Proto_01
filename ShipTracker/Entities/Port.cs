using System;

namespace ShipTracker.Entities
{
    public class Port:IComparable
    {
        public string Name { get; set; }
        public Country Country { get; set; }

        public Port(string name)
        {
            Name = name;
        }

        public Port(string  name, Country country):this(name)
        {
            Country = country;
        }

        public static Port At_Sea
        {
            get{return new Port("At Sea");}

        }

        public int CompareTo(object obj)
        {
            var port = obj as Port;
            if(port!=null)
            {
                if (port.Name == Name)
                    return 0;
            }
            return 1;
        }
    }
}
