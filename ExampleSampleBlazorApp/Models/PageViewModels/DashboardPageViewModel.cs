using System.ComponentModel;

namespace ExampleSampleBlazorApp.Models.PageViewModels
{
    /// <summary>
    /// Page ViewModel for the Dashboard Page
    /// </summary>
    /// <seealso cref="ExampleSampleBlazorApp.Models.ResponseWrapper" />
    public partial class DashboardPageViewModel
    {
        /// <summary>
        /// Gets or sets the API response data.
        /// </summary>
        /// <value>
        /// The API response data.
        /// </value>
        public ResponseWrapper? ApiResponseData { get; set; }



        /// <summary>
        /// Gets or sets the selected fact Count value, there is here for onchange triggers.
        /// </summary>
        /// <value>
        /// The selected fact Count.
        /// </value>
        [DefaultValue(10)]
        public int SelectedFactCount { get; set; }
    }
}