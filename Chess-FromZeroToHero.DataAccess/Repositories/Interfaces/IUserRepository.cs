using Chess_FromZeroToHero.DataAccess.Pagination;
using Chess_FromZeroToHero.Contracts.Dtos.User;

namespace Chess_FromZeroToHero.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserWithIdDto> GetUserByIdAsync(Guid id);

        Task<ICollection<UserWithIdDto>> GetUsersAsync(PaginationParams paginationParams);

        Task CreateUserAsync(UserDto dto);

        Task UpdateUserAsync(UserWithIdDto dto);

        Task DeleteUserAsync(UserWithIdDto dto);

        Task<int> DeleteAsync(Guid id);
    }
}
