using ExampleSampleBlazorApp._3rdParty;
using ExampleSampleBlazorApp.Models;
using ExampleSampleBlazorApp.Models._3rdParty;
using ExampleSampleBlazorApp.Services._3rdParty;

namespace ExampleSampleBlazorApp.Logic
{
    /// <summary>
    /// Binds our 3rd party API data to our response view model
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ComplexDataPackager"/> class.
    /// </remarks>
    /// <param name="factsService">The useless facts service.</param>
    /// <param name="meowService">The meow cat facts service.</param>
    public class ComplexDataPackager(IUselessFactsService factsService, IMeowFactsService meowService)
    {
        /// <summary>
        /// Packages the selected data into a response wrapper.
        /// </summary>
        /// <param name="catFactCount">The number of cat facts to load.</param>
        /// <param name="isRandomFactSelected">if set to <c>true</c> [is random fact selected].</param>
        /// <returns></returns>
        public async Task<ResponseWrapper> PackageSelectedData(
           int catFactCount = 10,
           bool isRandomFactSelected = true)
        {
            ResponseWrapper responseWrapper = new()
            {
                UserId = 1,
                CatFactCount = catFactCount,
                IsRandomFactSelected = isRandomFactSelected,
                TimeStamp = DateTime.Now.ToString(),
                //  First, we mate a remote API call to get a useless fact
                UselessFact = isRandomFactSelected ? await factsService.GetRandomFacts() : await factsService.GetRandomFacts()
            };

            //  Next, we call another API for an array of cat facts.  The array length should equal the catFactCount value
            CatFactsResponse response = meowService.GetMeowFacts(catFactCount).Result;
            responseWrapper.CatFacts = response.Data;

            return responseWrapper;
        }
    }
}