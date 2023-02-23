using Chess_FromZeroToHero.Contracts.Dtos.Pagination;
using Chess_FromZeroToHero.Contracts.Dtos.User;
using Chess_FromZeroToHero.Contracts.Helpers;
using Chess_FromZeroToHero.DataAccess.Entities;
using Chess_FromZeroToHero.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChessDbContext _dbContext;

        public UserRepository(ChessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserWithIdDto> GetUserById(Guid id)
        {
            User user = await _dbContext.Users.FindAsync(id);

            if (user is null)
            {
                throw new ArgumentNullException("User with given id not found");
            }

            return new UserWithIdDto 
            { 
                Id = user.Id,
                Name= user.Name,
                Age = user.Age,
                Username = user.Username,
                Password = user.Password,
                Rating = user.Rating,
                ProfilePicture = user.ProfilePicture,
            };
        }

        public async Task<ICollection<UserWithIdDto>> GetUsers(PaginationParams paginationParams)
        {
            var query = PaginationHelper.Paginate(_dbContext.Users, paginationParams);

            var users = await query
                .Select(user => new UserWithIdDto()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Age = user.Age,
                    Username = user.Username,
                    Password = user.Password,
                    Rating = user.Rating,
                    ProfilePicture = user.ProfilePicture,
                })
                .ToListAsync();

            return users;
        }
    }
}
