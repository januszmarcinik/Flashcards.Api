using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Exceptions;
using Flashcards.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Domain.Repositories.Concrete
{
    internal class EFUsersRepository : IUsersRepository
    {
        private readonly IDbContext _context;

        public EFUsersRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetAsync(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                throw new FlashcardsException(ErrorCode.UserWithGivenEmailDoesNotExist);
            }

            return user;
        }

        public async Task<User> GetAndEnsureExistAsync(Guid id)
        {
            var entity = await GetAsync(id);
            if (entity == null)
            {
                throw new FlashcardsException(ErrorCode.UserDoesNotExist, id.ToString());
            }

            return entity;
        }

        public Task<IQueryable<User>> QueryAsync()
        {
            return Task.FromResult(_context.Users.AsQueryable());
        }

        public async Task CreateAsync(User entity)
        {
            var existedUser = await _context.Users.SingleOrDefaultAsync(x => x.Email == entity.Email);
            if (existedUser != null)
            {
                throw new FlashcardsException(ErrorCode.UserWithGivenEmailAlreadyExist, entity.Email);
            }

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            var existedUser = await _context.Users
                .Where(x => x.Email == entity.Email)
                .Where(x => x.Id != entity.Id)
                .SingleOrDefaultAsync();
            if (existedUser != null)
            {
                throw new FlashcardsException(ErrorCode.UserWithGivenEmailAlreadyExist, entity.Email);
            }

            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
