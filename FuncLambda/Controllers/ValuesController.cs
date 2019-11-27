using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using microservice.Models;
using microservice.Repositories;

namespace microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IItemRepository _itemRepository;

        public ValuesController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ModelTableItems> GetAllData()
        {
            List<string> conditions = new List<string>();
            var items = await _itemRepository.Scan(conditions);
            return new ModelTableItems
            {
                Items = items
            };
        }

    }

    public class ModelTableItems
    {
        public IEnumerable<Item> Items { get; set; }
    }


}
