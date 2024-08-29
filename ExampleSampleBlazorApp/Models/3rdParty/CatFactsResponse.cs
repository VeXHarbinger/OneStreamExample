using Newtonsoft.Json;

namespace ExampleSampleBlazorApp.Models._3rdParty
{
    /// <summary>
    /// An API response object from the cat facts API
    /// </summary>
    public class CatFactsResponse
    {
        /// <summary>
        /// Gets or sets the Cat Facts data.
        /// </summary>
        /// <value>
        /// The Cat Facts data.
        /// </value>
        [JsonProperty("data")]
        public List<string> Data { get; set; }
    }
}