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
        Task<UserWithIdDto> GetByIdAsync(Guid id);

        Task<ICollection<UserWithIdDto>> GetAllAsync(PaginationParams paginationParams);

        Task CreateAsync(UserDto dto);

        Task<int> UpdateAsync(UserWithIdDto dto);

        Task<int> DeleteAsync(Guid id);
    }
}
