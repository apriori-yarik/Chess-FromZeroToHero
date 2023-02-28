using Chess_FromZeroToHero.Contracts.Dtos.User;
using Chess_FromZeroToHero.Contracts.Helpers;
using Chess_FromZeroToHero.DataAccess.Entities;
using Chess_FromZeroToHero.DataAccess.Pagination;
using Chess_FromZeroToHero.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        private async Task<User> GetEntityByIdAsync(Guid id)
        {
            var user = await _dbContext.User.FindAsync(id);

            return user;
        }

        public async Task<UserWithIdDto> GetByIdAsync(Guid id)
        {
            var user = await GetEntityByIdAsync(id);

            if (user is null)
            {
                return null;
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

        public async Task<ICollection<UserWithIdDto>> GetAllAsync(PaginationParams paginationParams)
        {
            var users = await _dbContext.User.AsNoTracking()
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
                .PaginateAsync(paginationParams);

            return users;
        }

        public async Task CreateAsync(UserDto dto)
        {
            var user = new User()
            {
                Name = dto.Name,
                Age = dto.Age,
                Username = dto.Username,
                Password = dto.Password,
                Rating = dto.Rating,
                ProfilePicture = dto.ProfilePicture,
            };

            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(UserWithIdDto dto)
        {
            var user = await GetEntityByIdAsync(dto.Id);

            if (user == null)
            {
                return false;
            }

            user.Name = dto.Name;
            user.Age = dto.Age;
            user.Username = dto.Username;
            user.Password = dto.Password;
            user.Rating = dto.Rating;
            user.ProfilePicture = dto.ProfilePicture;

            _dbContext.User.Update(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await _dbContext.User.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}
