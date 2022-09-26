using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessClassLibrary
{
    public class DataAccess : IService
    {
        private readonly string _apiKey = "apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private readonly string _apiURL = @"https://api-dev.channelengine.net/api/v2/";
        private readonly HttpClientHandler _clientHandler;

        public DataAccess()
        {
            this._clientHandler = new HttpClientHandler();
            this._clientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                };
        }
        public async Task<OrderView> GetAllOrder()
        {
            string apiURL = _apiURL + "orders/?" + _apiKey;
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync(apiURL))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    OrderView value = JsonConvert.DeserializeObject<OrderView>(apiResponse);
                    return value;
                }
            }
        }

        public async Task<Product> GetProduct(string productId)
        {
            if (!string.IsNullOrEmpty(productId))
            {
                string apiURL = _apiURL + "products/" + productId + "?" + _apiKey; //001201-XL
                using (var httpClient = new HttpClient(_clientHandler))
                {
                    using (var response = await httpClient.GetAsync(apiURL))
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        ProductView value = JsonConvert.DeserializeObject<ProductView>(apiResponse);
                        if (value != null)
                            return value.Content;
                    }
                }
            }
            return null;
        }

        public void PrintALine()
        {
            Console.WriteLine("This is a line");
        }
    }
}
