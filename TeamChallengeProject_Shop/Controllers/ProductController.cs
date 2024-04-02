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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService db, IMapper mapper)
        {
            _productService = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productService.GetProducts());
            return Ok(products);
        }

        [HttpGet("{productId:int}")]
        public IActionResult GetProduct(int productId)
        {
            var product = _mapper.Map<ProductDto>(_productService.GetProduct(productId));
            return Ok(product);
        }

        [HttpGet("{productName}")]
        public IActionResult GetProduct(string productName)
        {
            var product = _mapper.Map<ProductDto>(_productService.GetProduct(productName));
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDto productCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_productService.GetProductExists(productCreate.Name))
            {
                return BadRequest();
            }

            productCreate.Created_at = DateTime.Now;

            var product = _mapper.Map<Product>(productCreate);

            var newProduct = _productService.CreateProduct(product);

            if (newProduct is null)
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(newProduct);
        }
    }
}
