using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using Hospital;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Hospital.Tests.Integration
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetRoomEndpointReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/rooms");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }

        [Fact]
        public async Task PostRoomEndpointReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var roomViewModel = new RoomViewModel
            {
                RoomNumber = "101",
                Type = "Standard",
                Status = "Available",
                HospitalInfoId = 1 // Id of HospitalInfo
            };
            var json = JsonConvert.SerializeObject(roomViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/rooms", data);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }

        // Dodaj inne testy integracyjne w zale¿noœci od potrzeb
    }
}
