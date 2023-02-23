using Chess_FromZeroToHero.Contracts.Dtos.Pagination;
using Chess_FromZeroToHero.Contracts.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserWithIdDto> GetUserById(Guid id);

        Task<ICollection<UserWithIdDto>> GetUsers(PaginationParams paginationParams);
    }
}
