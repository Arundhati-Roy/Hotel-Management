using HotelReservationSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NUnitTestProject1
{
    public class Tests
    {
        HotelReservation hotelReservation = new HotelReservation();
        //Dictionary<string, Hotel> hotels;


        [SetUp]
        public void Setup()
        {
            hotelReservation = Program.AddSampleHotels(hotelReservation);

        }

        /// <summary>
        /// Adds the hotel
        /// Passes when hotel list contains the newly added hotel.
        /// </summary>
        [Test]
        public void AddHotel_WhenPassedNewHotel_AddsHotelToSystem()
        {
            var prevCount = hotelReservation.hotels.Count;
            var hotel = new Hotel { name = "MyHotel", weekdayRatesRegular = 10, weekendRatesRegular = 20 };

            //After adding count should increment by 1
            hotelReservation.AddHotel(hotel);

            Assert.That(hotelReservation.hotels.Count, Is.EqualTo(prevCount + 1));
            Assert.That(hotelReservation.hotels.ContainsKey(hotel.name), Is.True);
        }

        /// <summary>
        /// Finds the cheapest hotels when given valid date range 
        /// Checks for correct cheapest hotel.
        /// </summary>
        [Test]
        public void FindCheapestHotels_WhenGivenValidDateRange_ReturnsCheapestHotel()
        {
            var startDate = Convert.ToDateTime("10Sep2020");
            var endDate = Convert.ToDateTime("11Sep2020");

            //hotelReservation = Program.AddSampleHotels(hotelReservation);
            var expected = hotelReservation.hotels["Lakewood"];
            var result = hotelReservation.FindCheapestHotels(startDate, endDate, Program.CustomerType.Regular);
            
            Assert.That(result, Does.Contain(expected));
        }

        /// <summary>
        /// Finds the cheapest best rated hotels when given valid date range for regular 
        /// Checks for cheapest hotel with highest rating.
        /// </summary>
        [Test]
        public void FindCheapestBestRatedHotels_WhenGivenValidDateRangeForRegular_ReturnsCheapestHotelWithHighestRating()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("13Sep2020");

            var expected = hotelReservation.hotels["Bridgewood"];
            var result = hotelReservation.FindCheapestBestRatedHotel(startDate, endDate,Program.CustomerType.Regular);

            Assert.That(result, Does.Contain(expected));
        }

        /// <summary>
        /// Finds the best rated hotels when given valid date range
        /// Checks for the best rated hotel.
        /// </summary>
        [Test]
        public void FindBestRatedHotels_WhenGivenValidDateRange_ReturnsBestRatedHotel()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("13Sep2020");

            //hotelReservation = Program.AddSampleHotels(hotelReservation);
            var expected = hotelReservation.hotels["Ridgewood"];
            var result = hotelReservation.FindBestRatedHotel(startDate, endDate);

            Assert.That(result, Does.Contain(expected));
        }

        /// <summary>
        /// Finds the cheapest best rated hotels when given valid date range for loyalty customer
        /// checks for cheapest hotel with highest rating.
        /// </summary>
        [Test]
        public void FindCheapestBestRatedHotels_WhenGivenValidDateRangeForLoyalty_ReturnsCheapestHotelWithHighestRating()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("12Sep2020");

            //hotelReservation = Program.AddSampleHotels(hotelReservation);
            var expected = hotelReservation.hotels["Ridgewood"];
            var result = hotelReservation.FindCheapestBestRatedHotel(startDate, endDate,Program.CustomerType.Reward);

            Assert.That(result, Does.Contain(expected));
        }

        [TestCase(2)]
        [TestCase("")]
        [TestCase("Regular")]
        public void ThrowException_GivenInvalidCustomerType(Program.CustomerType cusType)
        {
            try
            {
                var startDate = Convert.ToDateTime("11Sep2020");
                var endDate = Convert.ToDateTime("13Sep2020");

                //hotelReservation = Program.AddSampleHotels(hotelReservation);
                var expected = hotelReservation.hotels["Bridgewood"];
                //cusType = "Reg";
                cusType = Program.GetCustomerType();
                var result = hotelReservation.FindCheapestBestRatedHotel(startDate, endDate, cusType);

                Assert.That(result, Does.Contain(expected));
            }
            catch (HotelReservationException e)
            {
                Assert.AreEqual(e, "Invalid customer type");
            }
        }
    }

}