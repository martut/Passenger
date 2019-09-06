using System;

namespace Passenger.Core.Domain
{
    public class Vehicle
    {
        public string Brand { get; protected set; }
        public string Name { get; protected set; }
        public int Seats { get; protected set; }


        protected Vehicle()
        {
            
        }

        public Vehicle(string brand, string name, int seats)
        {
            
        }

        private void SetBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new Exception($"Please provide valid data.");
            }

            if (Brand == brand)
            {
                return;
            }

            Brand = brand;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Please provide valid data.");
            }

            if (Name == name)
            {
                return;
            }

            Name = name;
            
        }

        private void SetSeats(int seats)
        {
            if (seats < 1)
            {
                throw new Exception($"There must be at least 1 seat.");
            }
            if (seats > 10)
            {
                throw new Exception($"You cannot provide more then 10 seats.");
            }

            if (Seats == seats)
            {
                return;
                ;
            }

            Seats = seats;
            

        }
    }
}