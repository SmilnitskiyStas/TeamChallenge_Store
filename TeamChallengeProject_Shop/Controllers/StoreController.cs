using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamChallengeProject_Shop.Models;
using TeamChallengeProject_Shop.Models.DTOs;
using TeamChallengeProject_Shop.Services.IServices;

namespace TeamChallengeProject_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _db;
        private readonly IMapper _mapper;

        public StoreController(IStoreService db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var stores = _mapper.Map<List<StoreDto>>(_db.GetAll());
            return Ok(stores);
        }

        [HttpGet]
        [Route("{storeId:int}")]
        public IActionResult GetById(int storeId)
        {
            var store = _mapper.Map<StoreDto>(_db.Get(storeId));
            return Ok(store);
        }

        [HttpGet]
        [Route("{storeName}")]
        public IActionResult GetByName(string storeName)
        {
            var store = _mapper.Map<StoreDto>(_db.Get(storeName));
            return Ok(store);
        }

        [HttpPost]
        public IActionResult CreateStore(StoreDto store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_db.GetExists(store.Name))
            {
                return BadRequest();
            }

            var model = _mapper.Map<Store>(store);

            if (model.Create_at == new DateTime())
            {
                model.Create_at = DateTime.Now;
            }
            var createStore = _db.Create(model);

            if (createStore is null)
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(createStore);
        }
    }
}
