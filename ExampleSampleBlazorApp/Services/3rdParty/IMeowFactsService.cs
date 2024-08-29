using ExampleSampleBlazorApp._3rdParty;
using ExampleSampleBlazorApp.Models._3rdParty;
using Refit;

namespace ExampleSampleBlazorApp._3rdParty
{
    /// <summary>
    /// API Service interface to the cat fact API
    /// </summary>
    public interface IMeowFactsService
    {
        /// <summary>
        /// Gets the indicated number of meow facts.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>an array of strings</returns>
        [Get("/?count={count}")]
        Task<CatFactsResponse> GetMeowFacts(int count);
    }
}