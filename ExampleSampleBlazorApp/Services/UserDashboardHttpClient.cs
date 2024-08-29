using System.Net.Http.Headers;
using System.Text;
using ExampleSampleBlazorApp.Models;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExampleSampleBlazorApp.Services
{
    public interface IUserDashboardHttpClient
    {
        Task<ResponseWrapper> getUserDashboardDataAsync(int catFactCount = 4, bool isRandomFactSelected = true);

        Task<ResponseWrapper> postUserDashboardDataAsync(RequestWrapper req);
    }

    /// <summary>
    /// HTTP Client for calling our DashboardData API
    /// </summary>
    public class UserDashboardHttpClient : IUserDashboardHttpClient
    {
        private readonly IHttpClientFactory _clientFactory = null!;
        private readonly JsonSerializerSettings _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDashboardHttpClient"/> class.
        /// </summary>
        /// <param name="clientFactory">The client factory.</param>
        public UserDashboardHttpClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        /// <summary>
        /// Gets the user dashboard data asynchronous.
        /// </summary>
        /// <param name="catFactCount">The cat fact count.</param>
        /// <param name="isRandomFactSelected">if set to <c>true</c> [is random fact selected].</param>
        /// <returns></returns>
        public async Task<ResponseWrapper> getUserDashboardDataAsync(int catFactCount = 4, bool isRandomFactSelected = true)
        {
            var _client = _clientFactory.CreateClient("MyHttpClient");
            var request = new HttpRequestMessage(HttpMethod.Get, $"UserDashboardData?catFactCount={catFactCount}&isRandomFactSelected={isRandomFactSelected}");
            var response = await _client.SendAsync(request);

            return await response.Content.ReadFromJsonAsync<ResponseWrapper>();
        }

        /// <summary>
        /// Posts the user dashboard data asynchronous.
        /// </summary>
        /// <param name="req">The RequestWrapper.</param>
        /// <returns></returns>
        public async Task<ResponseWrapper> postUserDashboardDataAsync(RequestWrapper req)
        {
            var _client = _clientFactory.CreateClient("MyHttpClient");
            var request = new HttpRequestMessage(HttpMethod.Post, "UserDashboardData");
            request.Content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);

            return await response.Content.ReadFromJsonAsync<ResponseWrapper>();
        }
    }
}