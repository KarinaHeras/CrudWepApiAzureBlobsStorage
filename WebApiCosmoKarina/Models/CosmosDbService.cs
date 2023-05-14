using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;

namespace WebApiCosmoKarina.Models
{
    public class CosmosDbService : IcosmosDBService
    {
        private Container _container;
        public CosmosDbService(CosmosClient cosmosDbClient, string databaseName, string containerName)
        {

            _container = cosmosDbClient.GetContainer(databaseName, containerName);
        }
        public async Task AddAsync(Coches item)
        {
            await _container.CreateItemAsync(item, new PartitionKey(item.Id));
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<Coches>(id, new PartitionKey(id));
        }

        public async Task<Coches> GetAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Coches>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException) //For handling item not found and other exceptions
            {
                return null;
            }
        }

        public async Task<IEnumerable<Coches>> GetMultipleAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<Coches>(new QueryDefinition(queryString));
            var results = new List<Coches>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task UpdateAsync(string id, Coches item)
        {
            await _container.UpsertItemAsync(item, new PartitionKey(id));
        }
    }
}
