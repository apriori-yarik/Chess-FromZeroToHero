using Chess_FromZeroToHero.Contracts.Dtos.User;
using Chess_FromZeroToHero.DataAccess.Pagination;
using Chess_FromZeroToHero.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Chess_FromZeroToHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(PaginationParams pagination)
        {
            var users = await _userService.GetAllAsync(pagination);

            if (users.IsNullOrEmpty())
            {
                return NoContent();
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserDto dto)
        {
            await _userService.CreateAsync(dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            int rowsAffected = await _userService.DeleteAsync(id);

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserWithIdDto dto)
        {
            var rowsAffected = await _userService.UpdateAsync(dto);

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
