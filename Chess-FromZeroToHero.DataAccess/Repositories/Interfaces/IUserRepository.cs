using Chess_FromZeroToHero.DataAccess.Pagination;
using Chess_FromZeroToHero.Contracts.Dtos.User;
using System.Linq.Expressions;

namespace Chess_FromZeroToHero.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserWithIdDto> GetByIdAsync(Guid id);

        Task<ICollection<UserWithIdDto>> GetAllAsync(PaginationParams paginationParams);

        Task<ICollection<UserWithIdDto>> GetAllFilteredAsync(Expression<Func<UserWithIdDto, bool>> filter = null);

        Task CreateAsync(UserDto dto);

        Task<int> UpdateAsync(UserWithIdDto dto);

        Task<int> DeleteAsync(Guid id);
    }
}
