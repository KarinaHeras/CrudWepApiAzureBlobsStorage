namespace WebApiCosmoKarina.Models
{
    public interface IcosmosDBService
    {
        Task<IEnumerable<Coches>> GetMultipleAsync(string query);
        Task<Coches> GetAsync(string id);
        Task AddAsync(Coches item);
        Task UpdateAsync(string id, Coches item);
        Task DeleteAsync(string id);
    }
}
