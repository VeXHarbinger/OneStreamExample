using System.Text.Json;

namespace ExampleSampleBlazorApp.Services.Core
{
    /// <summary>
    /// HTTP Client Cancellation Service, <see langword="for"/>issuing a stop command to long running processes.
    /// </summary>
    /// <seealso cref="ExampleSampleBlazorApp.Services.Core.IHttpClientServiceImplementation" />
    public class HttpClientCancellationService : IHttpClientServiceImplementation
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly JsonSerializerOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientCancellationService"/> class.
        /// </summary>
        public HttpClientCancellationService()
        {
            // ToDo: I didn't wire it all the way up, this was supposed to be a simple example
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            _cancellationTokenSource = new CancellationTokenSource();
        }

        private async Task GetCompaniesAndCancel(CancellationToken token)
        {
            try
            {
                using (var response = await _httpClient.GetAsync("Artists",
                HttpCompletionOption.ResponseHeadersRead, token))
                {
                    response.EnsureSuccessStatusCode();

                    var stream = await response.Content.ReadAsStreamAsync();
                    // ToDo: remove await JsonSerializer.DeserializeAsync
                    //  var com = await JsonSerializer.DeserializeAsync<List<ADto>>(stream, _options);
                }
            }
            catch (OperationCanceledException ocex)
            {
                Console.WriteLine(ocex.Message);
            }
        }

        public async Task Execute()
        {
            _cancellationTokenSource.CancelAfter(2000);
            await GetCompaniesAndCancel(_cancellationTokenSource.Token);
        }
    }
}