using KASHOP.DAL.Data;
using KASHOP.DAL.Dto;
using KASHOP.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Microsoft.EntityFrameworkCore;
namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase

    {

        ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            var categories = _context.categories.Include(c => c.Translations).ToList();

            var response = categories.Adapt<List<CategoryResponse>>();

            return Ok(response);
        }




        [HttpPost("")]
        public IActionResult create(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            _context.categories.Add(category);
            _context.SaveChanges();

           return Ok();
        }   
    }
}
