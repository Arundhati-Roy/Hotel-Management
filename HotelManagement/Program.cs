using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System!");

            var hotelReservation = new HotelReservation();
            var hotel = new Hotel();
            Console.Write("Enter Hotel Name : ");
            hotel.name = Console.ReadLine();

            Console.Write("Enter Regular Weekday Rate : ");
            hotel.weekdayRatesRegular = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Regular Weekend Rate : ");
            hotel.weekendRatesRegular = Convert.ToInt32(Console.ReadLine());

            hotelReservation.AddHotel(hotel);
            //hotelReservation.InitializeConsoleIO();
        }
    }
}
