
using System;
using Xunit;
using Shouldly;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;

namespace RoomBookingApp.Core
{
	public class RoomBookingRequestProcessorTest
	{
        private readonly RoomBookingRequestProcessor _processor;

        public RoomBookingRequestProcessorTest()
		{
			//Arrange
            _processor = new RoomBookingRequestProcessor();

        }	

		[Fact]
		public void Should_Return_Room_Booking_Response_With_Request_Values()
		{
            //Arrange
            var request = new RoomBookingRequest
			{
				FullName = "Test Name",
				Email="test@request.com",
				Date = new DateTime(2022,10,20)
			};

			//Act
			RoomBookingResult result = _processor.BookRoom(request);

			//Assert
			// Using X unit assert// Assert.NotNull(result);
			result.ShouldNotBeNull();
			request.FullName.ShouldBe(result.FullName);
            request.Email.ShouldBe(result.Email);
            request.Date.ShouldBe(result.Date);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
		{
            //Assert
            var exception = Should.Throw<ArgumentNullException>(() => _processor.BookRoom(null));
			exception.ParamName.ShouldBe("bookingRequest");
        }
    }
}

