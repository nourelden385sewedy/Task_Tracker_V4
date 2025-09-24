using Microsoft.EntityFrameworkCore;
using System;
using Task_Tracker_V4.Data;
using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.HelperClasses;
using Task_Tracker_V4.Data.Models;
using Task_Tracker_V4.Repositories.Interfaces;
using Task_Tracker_V4.Services;

namespace Task_Tracker_V4.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyDbContext _context;
        private readonly IRoleMapper _roleMapper;

        public AccountRepository(MyDbContext context, RoleMapper roleMapper)
        {
            _context = context;
            _roleMapper = roleMapper;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            return await _context.Accounts
                .Where(a => a.IsActive == true)
                .Select(a => new AccountDto
                {
                    Id = a.Id,
                    Name = a.FullNameEn,
                    Email = a.Email,
                    Phone = a.Phone,
                    RoleHash = _roleMapper.MapToRole(a.RoleId),
                    JoinDate = a.CreatedAt
                }).ToListAsync();

        }

        public async Task<Account?> GetByIdAsync(long id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
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
        public async Task<string?> GetAccountNameByIdAsync(long id)
        {
            var acc = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            return acc?.FullNameEn;
        }

        public async Task<long?> GetIdByNameAsync(string? name)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.FullNameEn == name);
            return account?.Id;
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
