﻿using Vehicle.Api.Entities;
using Vehicle.Api.Repository.Interfaces;
using Vehicle.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.HyperMedia;

namespace Vehicle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService itemService;
        private readonly ILogger<ItemController> logger;

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
        [HttpGet("{id}", Name = "GetItem")]
        public async Task<ActionResult<ApiResult>> GetItem(string id)
        {
            try
            {
                if (id != null)
                {
                    ApiResult result = await itemService.GetSingleAsync(id);
                    if (result == null)
                        return NotFound(new ApiResult(true, "item not found"));
                    var link = new LinkHelper<ApiResult>(result);
                    link.Links.Add(new Link { Href = Url.Link("GetItem", new { id }), Method = "GET" });
                    link.Links.Add(new Link { Href = Url.Link("AddItem", new { id }), Method = "POST" });
                    
                    return Ok(link);
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
                return BadRequest(ExceptionHelper.ProcessError(ex));
            }
        }

        /// <summary>
        /// Get all items 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Post item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost(Name ="AddItem")]
        public async Task<ActionResult<ApiResult>> PostItem([FromBody] Item item)
        {
            try
            {
                ApiResult result = await itemService.PostItem(item);
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
