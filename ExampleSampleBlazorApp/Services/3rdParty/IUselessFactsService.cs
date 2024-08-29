using ExampleSampleBlazorApp.Models._3rdParty;
using Refit;

namespace ExampleSampleBlazorApp.Services._3rdParty
{
    /// <summary>
    /// Our interface to the Useless Facts API
    /// </summary>
    public interface IUselessFactsService
    {
        /// <summary>
        /// Gets a daily facts.
        /// </summary>
        /// <returns>a populated <see cref="aFact" /> data model</returns>
        [Get("/api/v2/facts/today")]
        Task<aFact> GetDailyFacts();

        /// <summary>
        /// Gets a random facts.
        /// </summary>
        /// <returns>a populated <see cref="aFact" /> data model</returns>
        [Get("/api/v2/facts/random")]
        Task<aFact> GetRandomFacts();
    }
}