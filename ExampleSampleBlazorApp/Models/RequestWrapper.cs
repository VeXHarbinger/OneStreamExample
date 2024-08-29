using Newtonsoft.Json;
using System.ComponentModel;

namespace ExampleSampleBlazorApp.Models
{
    /// <summary>
    /// The common data structure that all our APIs expect
    /// </summary>
    /// <seealso cref="ExampleSampleBlazorApp.Models.BasicDataWrapper" />
    public partial class RequestWrapper : BasicDataWrapper
    {
        /// <summary>
        /// Gets or sets the number of facts to fetch.
        /// </summary>
        /// <value>
        /// The number of Cat facts to fetch.
        /// </value>
        [JsonProperty("catFactCount")]
        [DefaultValue(10)]
        public int CatFactCount { get; set; }

        /// <summary>
        /// Gets or sets the flag to indicate if the useless fact will be random, or about today.
        /// </summary>
        /// <value>
        /// The flag to indicate if the useless fact will be random, or about today.
        /// </value>
        [JsonProperty("isRandomFactSelected")]
        [DefaultValue(true)]
        public bool IsRandomFactSelected { get; set; }
    }
}