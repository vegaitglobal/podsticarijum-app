using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.DtoExtensions;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;


        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get([FromRoute] long id)
        {
            try
            {
                Category? category = await _categoryRepository.Get(id);
                if (category == null)
                {
                    return NotFound();
                }

                CategoryDto categoryDto = category.FromDomainModel();
                return Ok(categoryDto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost()]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryDto category)
        {
            try
            {
                if (category == null || category.NavMenuText == null)
                {
                    return BadRequest();
                }
                Category entity = category.ToDomainModel();
                category.Id = await _categoryRepository.Insert(entity);

                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] CategoryDto categoryDto)
        {
            if (isCategoryDtoValid(categoryDto))
            {
                return BadRequest();
            }

            Category? category = await _categoryRepository.Get(categoryDto.Id).ConfigureAwait(false);
            if (category == null)
            {
                return NotFound();
            }
            try
            {
                await _categoryRepository.Update(category);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private static bool isCategoryDtoValid(CategoryDto categoryDto)
            => categoryDto == null || categoryDto.Id != 0 || categoryDto.NavMenuText == null;
    }
}
