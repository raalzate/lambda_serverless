using Xunit;
using Moq;
using microservice.Repositories;
using Amazon.DynamoDBv2;
using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;
using System.Threading;

namespace microserviceTest
{
    public class ItemRepositoryTest
    {

        private string tableName = "microservice-dev";

        private Mock<IAmazonDynamoDB> amazonDynamoDBMock;


        private ItemRepository itemRepository;

        public ItemRepositoryTest()
        {
            amazonDynamoDBMock = new Mock<IAmazonDynamoDB>();

        }

        [Fact]
        public void ScanItems()
        {
            //arrage
            List<string> conditions = new List<string>();

            amazonDynamoDBMock
                .Setup(e => e.ScanAsync(tableName, conditions, It.IsAny<CancellationToken>()))
                .ReturnsAsync(GetDataset_ScanResponse());

            itemRepository = new ItemRepository(amazonDynamoDBMock.Object);

            //act
            var items = itemRepository.Scan(conditions).Result;

            //assert
            Assert.Equal(1, items[0].Id);
            Assert.Equal("Cali", items[0].Name);
            amazonDynamoDBMock
                .Verify(e => e.ScanAsync(tableName, conditions, It.IsAny<CancellationToken>()));
        }

        private ScanResponse GetDataset_ScanResponse()
        {
            var scan = new ScanResponse();
            Dictionary<string, AttributeValue> dict = new Dictionary<string, AttributeValue>();
            dict.Add("id", new AttributeValue("1"));
            dict.Add("name", new AttributeValue("Cali"));
            scan.Items.Add(dict);
            return scan;
        }
    }
}
