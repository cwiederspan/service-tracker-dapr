using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTracker.Models {

    public class Location {

        public double latitude { get; set; }

        public double longitude { get; set; }

        public Location(double lat, double lon) {
            this.latitude = lat;
            this.longitude = lon;
        }
    }

    public class Pushpin {

        public string color { get; set; }

        public Location location { get; set; }
    }
}
