using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using KASHOP.DAL.Data;
using Microsoft.Extensions.Localization;
namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        ApplicationDbContext _context;
       public UsersController(ApplicationDbContext context) {
                          _context=context;
                }


        public IActionResult index()
        {
            var users = _context.categories.ToList();
            return Ok();

        }

    }


}
