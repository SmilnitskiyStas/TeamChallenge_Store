using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TeamChallengeProject_Shop.Models;
using TeamChallengeProject_Shop.Models.DTOs;
using TeamChallengeProject_Shop.Services.IServices;

namespace TeamChallengeProject_Shop.Controllers
{
    [Route("api/stores")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public StoreController(IStoreService db, IMapper mapper)
        {
            _storeService = db;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetStores()
        {
            var stores = _mapper.Map<List<StoreDto>>(_storeService.GetStores());
            return Ok(stores);
        }

        [HttpGet]
        [Route("{storeId:int}")]
        public IActionResult GetStoreById(int storeId)
        {
            var store = _mapper.Map<StoreDto>(_storeService.GetStore(storeId));
            return Ok(store);
        }

        [HttpGet]
        [Route("{storeName}")]
        public IActionResult GetStoreByName(string storeName)
        {
            var store = _mapper.Map<StoreDto>(_storeService.GetStore(storeName));
            return Ok(store);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateStore(StoreDto store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_storeService.GetStoreExists(store.Name))
            {
                return BadRequest();
            }

            var model = _mapper.Map<Store>(store);

            if (model.Create_at == new DateTime())
            {
                model.Create_at = DateTime.Now;
            }
            var createStore = _storeService.CreateStore(model);

            if (createStore is null)
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(createStore);
        }

        [HttpPut]
        [Route("update/{storeId:int}")]
        public IActionResult UpdateStore(int storeId, [FromBody] StoreDto storeUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var store = _mapper.Map<Store>(storeUpdate);

            if (storeUpdate == null)
            {
                return BadRequest(ModelState);
            }

            if (_storeService.GetStore(storeId) is null)
            {
                return NotFound();
            }

            var updateModel = _storeService.UpdateStore(store);

            return Ok(updateModel);
        }

        [HttpPatch]
        [Route("patch/{storeId:int}")]
        public IActionResult PatchStore(int storeId, [FromBody] JsonPatchDocument<StoreDto> storeUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var store = _mapper.Map<Store>(_storeService.GetStore(storeId));

            if (storeUpdate == null)
            {
                return BadRequest(ModelState);
            }

            StoreDto storeDto = new StoreDto()
            {
                Name = store.Name,
                Create_at = store.Create_at,
                Delete_at = store.Delete_at,
            };

            storeUpdate.ApplyTo(storeDto);

            store.Name = storeDto.Name;
            store.Create_at = storeDto.Create_at;
            store.Delete_at = storeDto.Delete_at;

            return Ok(_storeService.UpdateStore(store));
        }

        [HttpDelete]
        [Route("delete/{storeId:int}")]
        public IActionResult DeleteStore(int storeId)
        {
            var store = _storeService.GetStore(storeId);
            var delete = _storeService.DeleteStore(store);
            return Ok(delete);
        }
    }
}
