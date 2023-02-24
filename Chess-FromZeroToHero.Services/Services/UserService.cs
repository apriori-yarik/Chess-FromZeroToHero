using Chess_FromZeroToHero.Contracts.Dtos.Pagination;
using Chess_FromZeroToHero.Contracts.Dtos.User;
using Chess_FromZeroToHero.DataAccess.Repositories.Interfaces;
using Chess_FromZeroToHero.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(UserDto dto) => await _userRepository.CreateUserAsync(dto);

        public async Task DeleteUserAsync(UserWithIdDto dto) => await _userRepository.DeleteUserAsync(dto);

        public async Task<UserWithIdDto> GetUserByIdAsync(Guid id) => await _userRepository.GetUserByIdAsync(id);

        public async Task<ICollection<UserWithIdDto>> GetUsersAsync(PaginationParams paginationParams) => await _userRepository.GetUsersAsync(paginationParams);

        public async Task UpdateUserAsync(UserWithIdDto dto) => await _userRepository.UpdateUserAsync(dto);
    }
}
