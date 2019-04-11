using Items.Api.Entities;
using Items.Api.Repository.Interfaces;
using Items.Api.Services.Interfaces;
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
        private readonly IItemService itemService;
        private readonly ILogger logger;

        public ItemController(IItemService service, ILogger<ItemController> _logger)
        {
            this.itemService = service;
            this.logger = _logger;
        }

        /// <summary>
        /// Get single item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> GetItem(string id)
        {
            try
            {
                if (id != null)
                {
                    ApiResult result = await itemService.GetSingle(id);
                    return Ok(result);
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

        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetAllItems()
        {
            try
            {
                ApiResult result = await itemService.GetAllItemsAsync();
                if (result.Status)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Exception when getting all items");
                return Ok(ex);
            }
        }

        [HttpPost]
        public ActionResult<ApiResult> PostItem([FromBody] Item item)
        {
            try
            {
                ApiResult result = itemService.PostItem(item);
                return Created("item created", result);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Exception when getting item");
                return Ok(ex);
            }

        }
    }
}
