using ExampleSampleBlazorApp._3rdParty;
using ExampleSampleBlazorApp.Logic;
using ExampleSampleBlazorApp.Models;
using ExampleSampleBlazorApp.Services._3rdParty;
using Microsoft.AspNetCore.Mvc;

namespace ExampleSampleBlazorApp.Controlers
{

    /// <summary>
    /// User Dashboard Data API Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class UserDashboardDataController(
        IUselessFactsService factsService,
        IMeowFactsService meowFactsService
    ) : ControllerBase
    {
        private readonly ComplexDataPackager cdp = new(factsService, meowFactsService);

        /// <summary>
        /// Gets the wrapped information pulled from the two 3rd party APIs.
        /// </summary>
        /// <param name="catFactCount">The number of cat facts to get.</param>
        /// <param name="isRandomFactSelected">if set to <c>true</c> [a random fact selected] else <c>false</c> [a fact about today is selected].</param>
        /// <returns>
        /// The users selected datasets
        /// </returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ResponseWrapper> GetData(int catFactCount = 4, bool isRandomFactSelected = true)
        {
            return await cdp.PackageSelectedData(catFactCount, isRandomFactSelected);
        }

        /// <summary>
        /// Using the two selection values we fetch and return the new data from the 3rd party APIs.
        /// </summary>
        /// <param name="requestValues">The request values.</param>
        /// <returns>The updated users selected datasets</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ResponseWrapper> GetData([FromBody] RequestWrapper requestValues)
        {
            return await cdp.PackageSelectedData(requestValues.CatFactCount, requestValues.IsRandomFactSelected);
        }
    }
}