using Microsoft.AspNetCore.Http;
using MatchMakerApi.Data;
using MatchMakerApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MatchMakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() 
        {
            var users = await _context.Users.ToListAsync();
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found in the database");
            }
            return Ok(users);
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                await _context.Database.OpenConnectionAsync();
                return Ok("Database connection is successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database connection failed: {ex.Message}");
            }
        }

    }
}
