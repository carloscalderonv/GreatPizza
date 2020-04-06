using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using GreatPizzaAPI.Contracts;
using GreatPizzaAPI.Contracts.V1.Requests;
using GreatPizzaAPI.Domains;
using Xunit;

namespace GreatPizzaAPI.Tests
{
    public class PizzaControllerTest : Test
    {

        [Fact]
        public async Task GetAll_WithoutAnyPizza_ReturnsEmptyResponse()
        {
            // Arrange

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Pizza.GetAll);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await Tool.ReadAsAsync<Pizza>(response.Content)).Should().NotBeNull();
        }

        [Fact]
        public async Task Get_ReturnsPizza_WhenPizzaExistsInTheDatabase()
        {
            // Arrange
            var createdPizza = await CreatePizzaAsync(new CreatePizzaRequest
            {
                Name = "new Pizza",
                Description = "Description"
            });

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Pizza.Get.Replace("{pizzaID}", createdPizza.Id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedPizza= await response.Content.ReadAsAsync<Pizza>();
            returnedPizza.Id.Should().Be(createdPizza.Id);
            returnedPizza.Name.Should().Be("new Pizza");
            returnedPizza.Description.Should().Be("Description");
        }
    }
}
