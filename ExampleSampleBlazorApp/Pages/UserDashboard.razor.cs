using ExampleSampleBlazorApp.Models;
using ExampleSampleBlazorApp.Models.PageViewModels;
using ExampleSampleBlazorApp.Services;
using Microsoft.AspNetCore.Components;

namespace ExampleSampleBlazorApp.Pages
{
    /// <summary>
    /// The functionality for the User Dashboard
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
    public partial class UserDashboard
    {
        private DashboardPageViewModel? pageViewModel;

        /// <summary>
        /// Gets our registered service.
        /// </summary>
        /// <value>
        /// The registered service.
        /// </value>
        [Inject]
        public IUserDashboardHttpClient dashboardClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            pageViewModel ??= new DashboardPageViewModel();
            pageViewModel.ApiResponseData = await dashboardClient.getUserDashboardDataAsync(7, false);
        }
    }
}