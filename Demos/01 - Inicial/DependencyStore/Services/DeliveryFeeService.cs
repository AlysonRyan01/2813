using DependencyStore.Services.Contracts;
using RestSharp;

namespace DependencyStore.Services
{
    public class DeliveryFeeService : IDeliveryFeeService
    {
        private readonly Configuration _configuration;

        public DeliveryFeeService(Configuration configuration)
        {
            _configuration = configuration;
        }

        public async Task<decimal> GetDeliveryFeeAsync(string zipCode)
        {
            var client = new RestClient(_configuration.DeliveryFeeServiceUrl);
            var request = new RestRequest()
            .AddJsonBody(new
            {
                ZipCode = zipCode
            });

            var deliveryFee = await client.PostAsync<decimal>(request);

            return deliveryFee == 0 ? 10 : deliveryFee;
        }
    }
}