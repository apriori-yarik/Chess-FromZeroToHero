using Chess_FromZeroToHero.Contracts.Dtos.User;
using Chess_FromZeroToHero.DataAccess.Pagination;
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

        public async Task CreateAsync(UserDto dto) => await _userRepository.CreateAsync(dto);

        public async Task<int> DeleteAsync(Guid id) => await _userRepository.DeleteAsync(id);

        public async Task<UserWithIdDto> GetByIdAsync(Guid id) => await _userRepository.GetByIdAsync(id);

        public async Task<ICollection<UserWithIdDto>> GetAllAsync(PaginationParams paginationParams) => await _userRepository.GetAllAsync(paginationParams);

        public async Task<bool> UpdateAsync(UserWithIdDto dto) => await _userRepository.UpdateAsync(dto);
    }
}
