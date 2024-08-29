namespace ExampleSampleBlazorApp.Services.Core
{
    /// <summary>
    /// Common Interface for Dtos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommonService<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);
    }
}