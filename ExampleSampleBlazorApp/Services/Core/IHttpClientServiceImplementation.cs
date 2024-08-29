namespace ExampleSampleBlazorApp.Services.Core
{
    /// <summary>
    /// The common base Http Client interface 
    /// </summary>
    public interface IHttpClientServiceImplementation
    {
        /// <summary>
        /// Execute.
        /// </summary>
        /// <returns></returns>
        Task Execute();
    }
}