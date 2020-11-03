using System;

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

                hotelReservation.AddHotel(hotel);

                Console.WriteLine("Wanna add more hotels?(yes/no)");
                if (Console.ReadLine() == "no")
                    val = false;
            }

            //UC2
            Console.Write("Enter the date range : ");
            var input = Console.ReadLine();
            string[] dates = input.Split(',');
            try
            {
                var startDate = Convert.ToDateTime(dates[0]);
                var endDate = Convert.ToDateTime(dates[1]);
                var cheapestHotel = hotelReservation.FindCheapestHotel(startDate, endDate);
                var cost = hotelReservation.CalculateTotalCost(cheapestHotel, startDate, endDate);
                Console.WriteLine("Hotel : {0}, Total Cost : {1}", cheapestHotel.name, cost);
            }
            catch
            {
                Console.Write("Enter the correct date range : ");
            }
            
        }
    }
}
