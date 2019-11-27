using System.Collections.Generic;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Threading.Tasks;
using System.Linq;
using microservice.Models;

namespace microservice.Repositories
{
    public class ItemRepository: IItemRepository
    {

        private const string TABLE_NAME = "microservice-dev";

        private readonly IAmazonDynamoDB _amazonDynamoDb;

        public ItemRepository(IAmazonDynamoDB amazonDynamoDb)
        {
            _amazonDynamoDb = amazonDynamoDb;
        }

        public async Task<List<Item>> Scan(List<string> conditions)
        {
            var result = await _amazonDynamoDb.ScanAsync(TABLE_NAME, conditions);
            return result.Items.Select(Map).ToList();
        }

        private Item Map(Dictionary<string, AttributeValue> result)
        {
            return new Item
            {
                Id = Convert.ToInt32(result["id"].S),
                Name = result["name"].S
            };
        }
    }

    public interface IItemRepository
    {
         Task<List<Item>> Scan(List<string> conditions);
    }

}