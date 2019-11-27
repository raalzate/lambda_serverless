using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;using System;
using System.Threading.Tasks;
using System.Linq;

namespace microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private const string TableName = "microservice-dev";

        private readonly IAmazonDynamoDB _amazonDynamoDb;

        public ValuesController(IAmazonDynamoDB amazonDynamoDb)
        {
            _amazonDynamoDb = amazonDynamoDb;
        }

        // GET api/values
        [HttpGet]
        public async Task<ModelTableItems> GetAllData()
        {
            List<String> conditions = new List<String>();

            var response = await _amazonDynamoDb.ScanAsync(TableName, conditions);
            return new ModelTableItems
            {
                Items = response.Items.Select(Map).ToList()
            };
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

    public class ModelTableItems
    {
        public IEnumerable<Item> Items { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}
