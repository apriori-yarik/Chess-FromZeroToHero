using Chess_FromZeroToHero.Contracts.Dtos.Pagination;
using Chess_FromZeroToHero.Contracts.Dtos.User;
using Chess_FromZeroToHero.Contracts.Helpers;
using Chess_FromZeroToHero.DataAccess.Entities;
using Chess_FromZeroToHero.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Chess_FromZeroToHero.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChessDbContext _dbContext;

        public UserRepository(ChessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task<User> GetUserEntityByIdAsync(Guid id)
        {
            User user = await _dbContext.Users.FindAsync(id);

            if (user is null)
            {
                throw new ArgumentNullException("User with given id not found");
            }

            return user;
        }

        public async Task<UserWithIdDto> GetUserByIdAsync(Guid id)
        {
            var user = await GetUserEntityByIdAsync(id);

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

        public async Task<ICollection<UserWithIdDto>> GetUsersAsync(PaginationParams paginationParams)
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

        public async Task CreateUserAsync(UserDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException("Cannot create user");
            }

            var user = new User()
            {
                Name = dto.Name,
                Age = dto.Age,
                Username = dto.Username,
                Password = dto.Password,
                Rating = dto.Rating,
                ProfilePicture = dto.ProfilePicture,
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserWithIdDto dto)
        {
            var user = await GetUserEntityByIdAsync(dto.Id);

            user.Name = dto.Name;
            user.Age = dto.Age;
            user.Username = dto.Username;
            user.Password = dto.Password;
            user.Rating = dto.Rating;
            user.ProfilePicture = dto.ProfilePicture;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await GetUserEntityByIdAsync(id);

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
