using Chess_FromZeroToHero.Contracts.Dtos.Pagination;
using Chess_FromZeroToHero.Contracts.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserWithIdDto> GetUserByIdAsync(Guid id);

        Task<ICollection<UserWithIdDto>> GetUsersAsync(PaginationParams paginationParams);

        Task CreateUserAsync(UserDto dto);

        Task UpdateUserAsync(UserWithIdDto dto);

        Task DeleteUserAsync(UserWithIdDto dto);
    }
}
