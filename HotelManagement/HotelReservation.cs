using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelReservation
    {
        public Dictionary<string, Hotel> hotels;

        public HotelReservation()
        {
            hotels = new Dictionary<string, Hotel>();
        }

        public void AddHotel(Hotel hotel)
        {
            if (hotels.ContainsKey(hotel.name))
            {
                Console.WriteLine("Hotel Already Exists");
                return;
            }
            hotels.Add(hotel.name, hotel);
        }

        public Hotel FindCheapestHotel(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                Console.WriteLine("Start date cannot be greater than end date");
            }

            var cost = Int32.MaxValue;
            Hotel cheapestHotel = new Hotel();
            foreach (var hotel in hotels)
            {
                var temp = cost;
                cost = Math.Min(cost, CalculateTotalCost(hotel.Value, startDate, endDate));
                if (temp != cost)
                    cheapestHotel = hotel.Value;
            }
            return cheapestHotel;
        }
        public int CalculateTotalCost(Hotel hotel, DateTime startDate, DateTime endDate)
        {
            var cost = 0;
            var weekdayRate = hotel.weekdayRatesRegular;
            var weekendRate = hotel.weekendRatesRegular;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    cost += weekendRate;
                else
                    cost += weekdayRate;
            }
            return cost;
        }
    }
}