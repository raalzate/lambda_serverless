using System;
using System.Collections.Generic;
using microservice.Controllers;
using microservice.Models;
using microservice.Repositories;
using Moq;
using Xunit;

namespace microserviceTest
{
    public class ValuesControllerTest
    {
        private Mock<IItemRepository> itemRepositoryMock;

        private ValuesController valuesControllerImp;
        public ValuesControllerTest(){
            itemRepositoryMock = new Mock<IItemRepository>();
        }

        [Fact]
        public void GetDataAll()
        { 
            itemRepositoryMock
                .Setup(e => e.Scan(It.IsAny<List<string>>()))
                .ReturnsAsync(GetDataset_Items());

            //Arrage
            valuesControllerImp = new ValuesController(itemRepositoryMock.Object);

            //Act
            var result = valuesControllerImp.GetAllData().Result;

            //Assert
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(result);

            Assert.Equal("{\"Items\":[{\"Id\":1,\"Name\":\"Cali\"}]}", json);
            itemRepositoryMock
                .Verify(e => e.Scan(It.IsAny<List<string>>()));
        }

        private List<Item> GetDataset_Items(){
            List<Item> items = new List<Item>();
            items.Add(new Item(1, "Cali"));
            return items;
        }

    }
}