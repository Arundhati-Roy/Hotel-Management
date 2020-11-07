using System;
using System.Collections.Generic;
using System.Text;
using static HotelReservationSystem.Program;

namespace HotelReservationSystem
{
    public class HotelReservation
    {
        //public enum CustomerType { Regular, Reward };

        public Dictionary<string, Hotel> hotels;

        public HotelReservation()
        {
            hotels = new Dictionary<string, Hotel>();
        }

        /// <summary>
        /// Adds the hotel.
        /// </summary>
        /// <param name="hotel">The hotel.</param>
        public void AddHotel(Hotel hotel)
        {
            if (hotels.ContainsKey(hotel.name))
            {
                Console.WriteLine("Hotel Already Exists");
                return;
            }
            hotels.Add(hotel.name, hotel);
        }

        /// <summary>
        /// Finds the cheapest hotels.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="ct">The ct.</param>
        /// <returns></returns>
        public List<Hotel> FindCheapestHotels(DateTime startDate, DateTime endDate,CustomerType ct)
        {
            var cost = Int32.MaxValue;
            var cheapestHotels = new List<Hotel>();
            if (startDate > endDate)
            {
                Console.WriteLine("Start date cannot be greater than end date");
                //Program.FindCheapest(hotelReservation);
                return null;
            }
            
            foreach (var hotel in hotels)
            {
                var temp = cost;
                cost = Math.Min(cost, CalculateTotalCost(hotel.Value, startDate, endDate,ct));

            }
            foreach (var hotel in hotels)
            {
                if (CalculateTotalCost(hotel.Value, startDate, endDate,ct) == cost)
                    cheapestHotels.Add(hotel.Value);
            }
            return cheapestHotels;
        }

        /// <summary>
        /// Calculates the total cost.
        /// </summary>
        /// <param name="hotel">The hotel.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="ct">The ct.</param>
        /// <returns></returns>
        public int CalculateTotalCost(Hotel hotel, DateTime startDate, DateTime endDate,CustomerType ct)
        {
            var cost = 0;
            var weekdayRate = ct == CustomerType.Regular ? hotel.weekdayRatesRegular : hotel.weekdayRatesLoyalty;
            var weekendRate = ct == CustomerType.Regular ? hotel.weekendRatesRegular : hotel.weekendRatesLoyalty;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    cost += weekendRate;
                else
                    cost += weekdayRate;
            }
            return cost;
        }

        /// <summary>
        /// Finds the cheapest best rated hotel.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="ct">The ct.</param>
        /// <returns></returns>
        public List<Hotel> FindCheapestBestRatedHotel(DateTime startDate, DateTime endDate,CustomerType ct)
        {
            var cheapestHotels = FindCheapestHotels(startDate, endDate,ct);
            var cheapestBestRatedHotels = new List<Hotel>();
            var maxRating = 1;
            foreach (var hotel in cheapestHotels)
                maxRating = Math.Max(maxRating, hotel.rating);
            foreach (var hotel in cheapestHotels)
                if (hotel.rating == maxRating)
                    cheapestBestRatedHotels.Add(hotel);
            return cheapestBestRatedHotels;
        }

        /// <summary>
        /// Finds the best rated hotel.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        public List<Hotel> FindBestRatedHotel(DateTime startDate, DateTime endDate)
        {
            var cheapestBestRatedHotels = new List<Hotel>();
            var maxRating = 0;
            foreach (var hotel in hotels)
                maxRating = Math.Max(maxRating, hotel.Value.rating);
            foreach (var hotel in hotels)
                if (hotel.Value.rating == maxRating)
                    cheapestBestRatedHotels.Add(hotel.Value);
            return cheapestBestRatedHotels;

        }
    }
}