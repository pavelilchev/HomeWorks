
using System;

namespace Problem1GalacticGPS
{
    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get { return this.latitude; }
            private set
            {
                if (value < 0 || value > 180)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Latitude should be in range 0..180"));
                }
                this.latitude = value;
            }
        }

        public double Longitude
        {
            get { return this.longitude; }
            private set
            {
                if (value < 0 || value > 180)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Longitude should be in range 0..360"));
                }
                this.latitude = value;
                this.longitude = value;
            }
        }

        public Planet Planet
        {
            get { return this.planet; }
            private set
            {
                this.planet = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} - {2}", this.Latitude, this.Longitude, this.Planet);
        }

    }
}
