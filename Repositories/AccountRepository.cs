using Microsoft.EntityFrameworkCore;
using System;
using Task_Tracker_V4.Data;
using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.Models;
using Task_Tracker_V4.Repositories.Interfaces;

namespace Task_Tracker_V4.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyDbContext _context;

        public AccountRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Account?> GetByIdAsync(long id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Account?> GetByEmailAsync(string email)
        {
            return await _context.Accounts.Include(a => a.Role).FirstOrDefaultAsync(x => x.Email == email);
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // --------------
        public Task<string?> GetAccountNameByIdAsync(long? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        

        

        public Task<long?> GetIdByNameAsync(string? name)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetRoleNameByAccountIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Add(Account account)
        {
            throw new NotImplementedException();
        }

        

        

    }
}
