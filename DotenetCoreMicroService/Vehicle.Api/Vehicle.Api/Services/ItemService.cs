﻿using Vehicle.Api.Entities;
using Vehicle.Api.Repository.Interfaces;
using Vehicle.Api.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vehicle.Api.Resources;

namespace Vehicle.Api.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository repository;
        private ILogger logger;
        private readonly IMapper mapper;

        public ItemService(IItemRepository repo, ILogger<ItemService> _logger, IMapper _mapper)
        {
            this.repository = repo ?? throw new ArgumentNullException(nameof(repo)); 
            this.logger = _logger ?? throw new ArgumentNullException(nameof(_logger));;
            this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper)); ;
        }

        public Task<ApiResult> DeleteItem(string id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Get all items asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResult> GetAllItemsAsync()
        {
            try
            {
                List<Item> items = await repository.GetAll();
                return new ApiResult(true, items);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Exception when getting all from repository");
                return new ApiResult(false, ex);
            }
        }

        /// <summary>
        /// Get single item asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResult> GetSingleAsync(string id)
        {
            try
            {
                Item item = await repository.GetSingle(id);
                if(item != null)
                {
                    var resource = mapper.Map<Item, ItemResource>(item);
                    return new ApiResult(true, resource);
                }
                else
                {
                    logger.LogWarning("Item returned is null");
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception when getting  from repository");
                return new ApiResult(false, ex);
            }
        }

        /// <summary>
        /// Adding item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<ApiResult> PostItem(Item item)
        {
            try
            {
                item.GUID = item.GetGUID();
                await repository.Add(item);
                return new ApiResult(true, item);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Exception when adding to repository");
                return new ApiResult(false, ex);
            }
        }

        public async Task<ApiResult> UpdateItem(Item item)
        {
            try
            {
                item.GUID = item.GetGUID();
                await repository.Update(item);
                return new ApiResult(true, item);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Exception when adding to repository");
                return new ApiResult(false, ex);
            }
        }
    }
}
