using Newtonsoft.Json;

namespace ExampleSampleBlazorApp.Models
{
    /// <summary>
    /// The Base data model that all requests and responses contain
    /// </summary>
    public partial class BasicDataWrapper
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [JsonProperty("userId")]
        public int UserId { get; set; }
    }
}