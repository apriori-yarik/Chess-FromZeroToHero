using Chess_FromZeroToHero.Contracts.Dtos.Pagination;
using Chess_FromZeroToHero.Contracts.Dtos.User;
using Chess_FromZeroToHero.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync(PaginationParams pagination)
        {
            var users = await _userService.GetUsersAsync(pagination);

            if (users is null)
            {
                return NoContent();
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            await _userService.CreateUserAsync(dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(user);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(UserWithIdDto dto)
        {
            var user = await _userService.GetUserByIdAsync(dto.Id);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.UpdateUserAsync(dto);

            return Ok();
        }
    }
}
