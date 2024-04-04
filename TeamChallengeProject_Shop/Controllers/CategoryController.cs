using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TeamChallengeProject_Shop.Models;
using TeamChallengeProject_Shop.Models.DTOs;
using TeamChallengeProject_Shop.Services.IServices;

namespace TeamChallengeProject_Shop.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryService.GetCategories());

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [HttpGet]
        [Route("{categoryId:int}")]
        public IActionResult GetCategory(int categoryId)
        {
            var category = _mapper.Map<CategoryDto>(_categoryService.GetCategory(categoryId));

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet]
        [Route("{categoryName}")]
        public IActionResult GetCategory(string categoryName)
        {
            var category = _mapper.Map<CategoryDto>(_categoryService.GetCategory(categoryName));

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        [Route("create/")]
        public IActionResult CreateCategory(CategoryDto model) 
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_categoryService.GetCategoryExists(model.Name))
            {
                return BadRequest();
            }
            var category = _mapper.Map<Category>(model);

            if (_categoryService.CreateCategory(category) == null)
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(category);
        }

        [HttpPut]
        [Route("update/{categoryId:int}")]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDto categoryUpdate)
        {
            if (categoryId <= 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_categoryService.GetCategoryExists(categoryUpdate.Name))
            {
                return BadRequest();
            }

            var model = _mapper.Map<Category>(categoryUpdate);

            if (_categoryService.UpdateCategory(model) == null)
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(model);
        }

        [HttpPatch]
        [Route("patch/{categoryId:int}")]
        public IActionResult PatchCategory(int categoryId, [FromBody] JsonPatchDocument<CategoryDto> model)
        {
            if (categoryId <= 0)
            {
                return BadRequest();
            }

            var category = _mapper.Map<Category>(_categoryService.GetCategory(categoryId));

            if (category == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            CategoryDto categoryDto = new CategoryDto()
            {
                Name = category.Name,
                ParentId = category.ParentId,
                Create_at = category.Create_at,
                Delete_at = category.Delete_at,
            };

            model.ApplyTo(categoryDto);

            category.Name = categoryDto.Name;
            category.ParentId = categoryDto.ParentId;
            category.Create_at = categoryDto.Create_at;
            category.Delete_at = categoryDto.Delete_at;

            if (_categoryService.UpdateCategory(category) == null)
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(category);
        }

        [HttpDelete]
        [Route("delete/{categoryId:int}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                return BadRequest();
            }

            if (_categoryService.GetCategory(categoryId) == null)
            {
                return NotFound();
            }

            if (_categoryService.DeleteCategory(categoryId))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
