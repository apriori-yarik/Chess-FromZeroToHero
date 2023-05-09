using AutoMapper;
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
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Chess_FromZeroToHero.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChessDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(ChessDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserWithIdDto> GetByIdAsync(Guid id)
        {
            var user = await _dbContext.User.FindAsync(id);

            if (user is null)
            {
                return null;
            }

            return new UserWithIdDto 
            { 
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Username = user.Username,
                Rating = user.Rating,
            };
        }

        public async Task<ICollection<UserWithIdDto>> GetAllAsync(PaginationParams paginationParams)
        {
            var users = await _dbContext.User.AsNoTracking()
                .Select(user => new UserWithIdDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Username = user.Username,
                    Rating = user.Rating,
                })
                .PaginateAsync(paginationParams);

            return users.OrderBy(x => x.Rating).ToList();
        }

        public async Task<ICollection<UserWithIdDto>> GetAllFilteredAsync(Expression<Func<UserWithIdDto, bool>> filter = null)
        {
            IQueryable<User> query = _dbContext.User;

            if (filter != null)
            {
                query.Where(_mapper.Map<Expression<Func<User, bool>>>(filter));
            }

            var filtered = _mapper.ProjectTo<UserWithIdDto>(query);

            return await filtered.ToListAsync();
        }

        public async Task CreateAsync(UserDto dto)
        {
            var user = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                Username = dto.Username,
                Password = dto.Password,
                Rating = dto.Rating,
            };

            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(UserWithIdDto dto)
        {
            var user = await _dbContext.User.FindAsync(dto.Id);

            if (user == null)
            {
                return 0;
            }

            return await _dbContext.User.Where(x => x.Id == dto.Id).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.FirstName, x => dto.FirstName)
                .SetProperty(x => x.LastName, x => dto.LastName)
                .SetProperty(x => x.BirthDate, x => dto.BirthDate)
                .SetProperty(x => x.Username, x => dto.Username)
                .SetProperty(x => x.Password, x => dto.Password)
                .SetProperty(x => x.Rating, x => dto.Rating)
            );
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await _dbContext.User.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}
