using Items.Api.Entities;
using Items.Api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Items.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository repository;
        private readonly ILogger logger;

        public ItemController(IItemRepository repo, ILogger<ItemController> _logger)
        {
            this.repository = repo;
            this.logger = _logger;
        }

        /// <summary>
        /// Get single item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(string id)
        {
            try
            {
                if (id != null)
                {
                    Item item = repository.GetSingle(id);
                    return Ok(item);
                }
                else
                {
                    logger.LogWarning("ID is null");
                    return BadRequest("Item id is null");
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Exception when getting item");
                return null;
            }

        }

        [HttpPost]
        public ActionResult PostItem([FromBody] Item item)
        {
            try
            {
                repository.Add(item);
                return Created("Item created", item);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Exception when getting item");
                return null;
            }

        }
    }
}
