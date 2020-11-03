using System;
using System.Collections.Generic;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System!");

            var hotelReservation = new HotelReservation();
            bool val = true;
            //Console.WriteLine("How many hotels do you want?");
            //int n = Convert.ToInt32(Console.ReadLine());
            while(val)
            {
                var hotel = new Hotel();
                Console.Write("Enter Hotel Name : ");
                hotel.name = Console.ReadLine();

                Console.Write("Enter Regular Weekday Rate : ");
                hotel.weekdayRatesRegular = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Regular Weekend Rate : ");
                hotel.weekendRatesRegular = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Hotel Rating (5 being best, 1 being worst) : ");
                hotel.rating = Convert.ToInt32(Console.ReadLine());

                hotelReservation.AddHotel(hotel);

                Console.WriteLine("Wanna add more hotels?(yes/no)");
                if (Console.ReadLine() == "no")
                    val = false;
            }
            FindCheapest(hotelReservation);
            FindCheapestBest(hotelReservation);
            /*Console.WriteLine("1.Cheapest or 2.Best cheapest?");
            switch(Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    {
                        FindCheapest(hotelReservation);
                        break;
                    }
                case 2:
                    {
                        FindCheapestBest(hotelReservation);
                        break;
                    }
            }
            */
        }
        //UC2 - UC4           
        public static void FindCheapest(HotelReservation hotelReservation)
        {
            Console.WriteLine("Cheapest Hotel");
            Console.Write("Enter the date range : ");
            var input = Console.ReadLine();
            string[] dates = input.Split(',');
            try
            {
                var startDate = Convert.ToDateTime(dates[0]);
                var endDate = Convert.ToDateTime(dates[1]);
                var cheapestHotel = hotelReservation.FindCheapestHotels(startDate, endDate);
                foreach (Hotel h in cheapestHotel)
                {
                    var cost = hotelReservation.CalculateTotalCost(h, startDate, endDate);
                    Console.WriteLine("Hotel : {0}, Total Cost : {1}", h.name, cost);
                }
            }
            catch
            {
                Console.Write("Enter the correct date range \n");
                FindCheapest(hotelReservation);
            }
        }

        //UC6          
        public static void FindCheapestBest(HotelReservation hotelReservation)
        {
            Console.WriteLine("Cheapest Best Rated Hotel");
            Console.Write("Enter the date range : ");
            var input = Console.ReadLine();
            string[] dates = input.Split(',');
            try
            {
                var startDate = Convert.ToDateTime(dates[0]);
                var endDate = Convert.ToDateTime(dates[1]);
                var cheapestHotel = hotelReservation.FindCheapestBestRatedHotel(startDate, endDate);
                foreach (Hotel h in cheapestHotel)
                {
                    var cost = hotelReservation.CalculateTotalCost(h, startDate, endDate);
                    Console.WriteLine("Hotel : {0}, Rating: {1}, Total Cost : {2}", h.name,h.rating, cost);
                }
            }
            catch
            {
                Console.Write("Enter the correct date range \n");
                FindCheapest(hotelReservation);
            }
        }

    }
}
