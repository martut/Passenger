using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class Node
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        protected Node()
        {
        }

        protected Node(string address, double longitude, double latitude)
        {
            SetAdress(address);
            SetLongitude(longitude);
            SetLatitude(latitude);
        }

        public string Address { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        private void SetLatitude(double latitude)
        {
            if (double.IsNaN(latitude)) throw new Exception("Latitude must be a number.");

            if (Latitude == latitude) return;

            Latitude = latitude;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetLongitude(double longitude)
        {
            if (double.IsNaN(longitude)) throw new Exception("Longitude must be a number.");

            if (Longitude == longitude) return;

            Longitude = longitude;
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetAdress(string address)
        {
            if (!NameRegex.IsMatch(address)) throw new Exception("Adress is invalid.");

            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}