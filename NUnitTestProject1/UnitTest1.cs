using HotelReservationSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    public class Tests
    {
        HotelReservation hotelReservation = new HotelReservation();
        //Dictionary<string, Hotel> hotels;


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddHotel_WhenPassedNewHotel_AddsHotelToSystem()
        {
            var hotel = new Hotel { name = "MyHotel", weekdayRatesRegular = 10, weekendRatesRegular = 20 };

            var prevCount = hotelReservation.hotels.Count;
            //After adding count should increment by 1
            hotelReservation.AddHotel(hotel);

            Assert.That(hotelReservation.hotels.Count, Is.EqualTo(prevCount + 1));
            Assert.That(hotelReservation.hotels.ContainsKey(hotel.name), Is.True);
        }
        [Test]
        public void FindCheapestHotels_WhenGivenValidDateRange_ReturnsCheapestHotel()
        {
            var startDate = Convert.ToDateTime("10Sep2020");
            var endDate = Convert.ToDateTime("11Sep2020");

            hotelReservation = Program.AddSampleHotels(hotelReservation);
            var expected = hotelReservation.hotels["Lakewood"];
            var result = hotelReservation.FindCheapestHotels(startDate, endDate, Program.CustomerType.Regular);
            
            Assert.That(result, Does.Contain(expected));

        }
        [Test]
        public void FindCheapestBestRatedHotels_WhenGivenValidDateRangeForRegular_ReturnsCheapestHotelWithHighestRating()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("13Sep2020");

            hotelReservation = Program.AddSampleHotels(hotelReservation);
            var expected = hotelReservation.hotels["Bridgewood"];
            var result = hotelReservation.FindCheapestBestRatedHotel(startDate, endDate,Program.CustomerType.Regular);

            Assert.That(result, Does.Contain(expected));
        }
        [Test]
        public void FindBestRatedHotels_WhenGivenValidDateRange_ReturnsBestRatedHotel()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("13Sep2020");

            hotelReservation = Program.AddSampleHotels(hotelReservation);
            var expected = hotelReservation.hotels["Ridgewood"];
            var result = hotelReservation.FindBestRatedHotel(startDate, endDate);

            Assert.That(result, Does.Contain(expected));
        }
        [Test]
        public void FindCheapestBestRatedHotels_WhenGivenValidDateRangeForLoyalty_ReturnsCheapestHotelWithHighestRating()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("12Sep2020");

            hotelReservation = Program.AddSampleHotels(hotelReservation);
            var expected = hotelReservation.hotels["Ridgewood"];
            var result = hotelReservation.FindCheapestBestRatedHotel(startDate, endDate,Program.CustomerType.Reward);

            Assert.That(result, Does.Contain(expected));
        }
        

    }

}