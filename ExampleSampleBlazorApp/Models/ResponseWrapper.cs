using ExampleSampleBlazorApp.Models._3rdParty;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExampleSampleBlazorApp.Models
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="ExampleSampleBlazorApp.Models.RequestWrapper" />
    [Serializable]
    public partial class ResponseWrapper : RequestWrapper
    {
        /// <summary>
        /// Gets or sets a list of cat facts.
        /// </summary>
        /// <value>
        /// A list of cat facts.
        /// </value>
        public List<string> CatFacts { get; set; } = [];

        /// <summary>
        /// Gets or sets the response or error message.
        /// </summary>
        /// <value>
        /// The response or error message.
        /// </value>
        [JsonProperty("message")]
        [DataType(DataType.Text)]
        [DefaultValue("")]
        public string Message { get; set; } = "";

        /// <summary>
        /// Gets or sets the generated at time stamp of this data.
        /// </summary>
        /// <value>
        /// The data's time stamp.
        /// </value>
        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; } = "";

        /// <summary>
        /// Gets or sets either a random useless fact, or one about today.
        /// </summary>
        /// <value>
        /// A random useless fact, or one about today.
        /// </value>
        [JsonProperty("uselessFact")]
        public aFact? UselessFact { get; set; }
    }
}