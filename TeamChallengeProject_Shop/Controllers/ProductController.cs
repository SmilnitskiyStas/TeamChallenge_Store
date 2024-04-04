using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TeamChallengeProject_Shop.Models;
using TeamChallengeProject_Shop.Models.DTOs;
using TeamChallengeProject_Shop.Services.IServices;

namespace TeamChallengeProject_Shop.Controllers
{
    [Route("api/products")]
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

        [HttpGet]
        [Route("{productId:int}")]
        public IActionResult GetProduct(int productId)
        {
            var product = _mapper.Map<ProductDto>(_productService.GetProduct(productId));
            return Ok(product);
        }

        [HttpGet]
        [Route("{productName}")]
        public IActionResult GetProduct(string productName)
        {
            var product = _mapper.Map<ProductDto>(_productService.GetProduct(productName));
            return Ok(product);
        }

        [HttpPost]
        [Route("create/")]
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

        [HttpPut]
        [Route("update/{productId:int}")]
        public IActionResult UpdateProduct(int productId, [FromBody] ProductDto productUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = _mapper.Map<Product>(productUpdate);

            if (productUpdate is null)
            {
                return BadRequest(ModelState);
            }

            if (_productService.GetProduct(productId) is null)
            {
                return NotFound();
            }

            var updateModel = _productService.UpdateProduct(product);

            if (updateModel is null)
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(updateModel);
        }

        [HttpPatch]
        [Route("patch/{productId:int}")]
        public IActionResult PutchProduct(int productId, [FromBody] JsonPatchDocument<ProductDto> productUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = _mapper.Map<Product>(_productService.GetProduct(productId));

            if (product is null)
            {
                return NotFound(ModelState);
            }

            ProductDto productDto = new ProductDto()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                PickUp = product.PickUp,
                Delivery = product.Delivery,
                Created_at = product.Created_at,
                Delete_at = product.Delete_at,
            };

            productUpdate.ApplyTo(productDto);

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Quantity = productDto.Quantity;
            product.PickUp = productDto.PickUp;
            product.Delivery = productDto.Delivery;
            product.Created_at = productDto.Created_at;
            product.Delete_at = productDto.Delete_at;

            if (_productService.UpdateProduct(product) is null)
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(product);
        }

        [HttpDelete]
        [Route("delete/{productId:int}")]
        public IActionResult DeleteProduct(int productId)
        {
            if (productId <= 0)
            {
                return BadRequest();
            }

            if (_productService.GetProductExists(_productService.GetProduct(productId).Name))
            {
                return NotFound();
            }

            if (_productService.DeleteProduct(productId))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}
