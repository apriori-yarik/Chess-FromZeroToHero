using Chess_FromZeroToHero.Contracts.Dtos.User;
using Chess_FromZeroToHero.DataAccess.Pagination;
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

        Task<int> DeleteAsync(Guid id);
    }
}
