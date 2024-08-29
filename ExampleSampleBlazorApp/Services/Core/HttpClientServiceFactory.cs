using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExampleSampleBlazorApp.Services.Core
{
    /// <summary>
    /// Base HTTP Client Service Factory
    /// </summary>
    /// <seealso cref="ExampleSampleBlazorApp.Services.Core.IHttpClientServiceImplementation" />
    public class HttpClientServiceFactory : IHttpClientServiceImplementation
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientServiceFactory"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        public HttpClientServiceFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
        }

        /// <summary>
        /// Executes the factory task.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task Execute()
        {
            throw new NotImplementedException();
        }
    }
}