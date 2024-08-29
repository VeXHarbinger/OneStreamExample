using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExampleSampleBlazorApp.Models._3rdParty
{
    /// <summary>
    /// The response object returned by the fact API
    /// </summary>
    [Serializable]
    public class aFact
    {
        /// <summary>
        /// Gets or sets the unique identifier for this record.
        /// </summary>
        /// <value>
        /// The unique identifier for this record.
        /// </value>
        [JsonProperty("id")]
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the two letter code for it's language. default: en
        /// </summary>
        /// <value>
        /// The two letter code for language.
        /// </value>
        [JsonProperty("language")]
        [DataType(DataType.Text)]
        [DefaultValue("en")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the canonical URI to the fact.
        /// </summary>
        /// <value>
        /// The canonical URI to the fact.
        /// </value>
        [JsonProperty("permalink")]
        [DataType(DataType.Url)]
        public string? Permalink { get; set; }

        /// <summary>
        /// Gets or sets the source domain where we learned of the fact.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        [DataType(DataType.Text)]
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the source URL where we learned the fact from.
        /// </summary>
        /// <value>
        /// The source URL where we learned the fact from.
        /// </value>
        [JsonProperty("source_url")]
        [DataType(DataType.Url)]
        public string Source_Url { get; set; }

        /// <summary>
        /// Gets or sets the text about the Fact.
        /// </summary>
        /// <value>
        /// The text about the Fact.
        /// </value>
        [JsonProperty("text")]
        [DataType(DataType.Text)]
        [DefaultValue("")]
        public string Text { get; set; }
    }
}