
using System;
using Xunit;
using Shouldly;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;

namespace RoomBookingApp.Core
{
	public class RoomBookingRequestProcessorTest
	{
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

			var processor = new RoomBookingRequestProcessor();

			//Act
			RoomBookingResult result = processor.BookRoom(request);

			//Assert
			// Using X unit assert// Assert.NotNull(result);
			result.ShouldNotBeNull();
			request.FullName.ShouldBe(result.FullName);
            request.Email.ShouldBe(result.Email);
            request.Date.ShouldBe(result.Date);
        }

	}
}

