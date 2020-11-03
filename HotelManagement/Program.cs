using System;
using System.Collections.Generic;

namespace HotelReservationSystem
{
    class Program
    {
        public enum CustomerType { Regular,Reward};

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System!");

            var hotelReservation = new HotelReservation();

            //AddHotelManually(hotelReservation);
            AddSampleHotels(hotelReservation);

            FindCheapest(hotelReservation);
            FindCheapestBest(hotelReservation);
            FindBest(hotelReservation);
            /*Console.WriteLine("1.Cheapest or 2.Best cheapest or 3.Best Rated?");
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
                case 3:
                    {
                        FindBest(hotelReservation);
                        break;
                    }
            }
            */
        }
        //UC1
        public static HotelReservation AddHotelManually(HotelReservation hotelReservation)
        {
            bool val = true;
            while (val)
            {
                var hotel = new Hotel();
                Console.Write("Enter Hotel Name : ");
                hotel.name = Console.ReadLine();

                Console.Write("Enter Regular Weekday Rate : ");
                hotel.weekdayRatesRegular = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Regular Weekend Rate : ");
                hotel.weekendRatesRegular = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Loyalty Weekday Rate :  ");
                hotel.weekdayRatesLoyalty = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Loyalty Weekend Rate :  ");
                hotel.weekendRatesLoyalty = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Hotel Rating (5 being best, 1 being worst) : ");
                hotel.rating = Convert.ToInt32(Console.ReadLine());

                hotelReservation.AddHotel(hotel);

                Console.WriteLine("Wanna add more hotels?(yes/no)");
                if (Console.ReadLine() == "no")
                    val = false;
            }
            return hotelReservation;
        }

        public static HotelReservation AddSampleHotels(HotelReservation hotelReservation)
        {
            hotelReservation.AddHotel(new Hotel { name = "Lakewood", weekdayRatesRegular = 110, weekendRatesRegular = 90, weekdayRatesLoyalty = 80, weekendRatesLoyalty = 80, rating = 3 });
            hotelReservation.AddHotel(new Hotel { name = "Bridgewood", weekdayRatesRegular = 160, weekendRatesRegular = 60, weekdayRatesLoyalty = 110, weekendRatesLoyalty = 50, rating = 4 });
            hotelReservation.AddHotel(new Hotel { name = "Ridgewood", weekdayRatesRegular = 220, weekendRatesRegular = 150, weekdayRatesLoyalty = 100, weekendRatesLoyalty = 40, rating = 5 });

            return hotelReservation;

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
        //UC7          
        public static void FindBest(HotelReservation hotelReservation)
        {
            Console.WriteLine("Cheapest Best Rated Hotel");
            Console.Write("Enter the date range : ");
            var input = Console.ReadLine();
            string[] dates = input.Split(',');
            try
            {
                var startDate = Convert.ToDateTime(dates[0]);
                var endDate = Convert.ToDateTime(dates[1]);
                var cheapestHotel = hotelReservation.FindBestRatedHotel(startDate, endDate);
                foreach (Hotel h in cheapestHotel)
                {
                    var cost = hotelReservation.CalculateTotalCost(h, startDate, endDate);
                    Console.WriteLine("Hotel : {0}, Rating: {1}, Total Cost : {2}", h.name, h.rating, cost);
                }
            }
            catch
            {
                Console.Write("Enter the correct date range \n");
                FindCheapest(hotelReservation);
            }
        }
        //UC 9
        public static CustomerType GetCustomerType(CustomerType customer)
        {
            Console.Write("Enter the type of Customer : ");
            var cusType = Console.ReadLine().ToLower();
            if (cusType != "regular" && cusType != "reward")
                throw new HotelReservationException(ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type Entered");
            return cusType == "regular" ? CustomerType.Regular : CustomerType.Reward;
        }

    }
}
