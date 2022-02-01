using Food_Center.Model;
using Food_Center.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Center.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepositor categoryRepository;

        public CategoryController(ICategoryRepositor  categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
       
        [HttpPost("category")]
        public async Task<IActionResult> AddCategory(CategoryModel categoryModel)
        {
            var resultt = categoryRepository.AddCategoryNew(categoryModel);
            return Ok(resultt.Result);
        }
    }
}
