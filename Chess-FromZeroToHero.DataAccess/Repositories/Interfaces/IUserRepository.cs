using Chess_FromZeroToHero.DataAccess.Pagination;
using Chess_FromZeroToHero.Contracts.Dtos.User;

namespace Chess_FromZeroToHero.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserWithIdDto> GetByIdAsync(Guid id);

        Task<ICollection<UserWithIdDto>> GetAllAsync(PaginationParams paginationParams);

        Task CreateAsync(UserDto dto);

        Task UpdateAsync(UserWithIdDto dto);

        Task<int> DeleteAsync(Guid id);
    }
}
