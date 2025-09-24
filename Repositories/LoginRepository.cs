using Microsoft.EntityFrameworkCore;
using System;
using Task_Tracker_V4.Data;
using Task_Tracker_V4.Data.Models;
using Task_Tracker_V4.Repositories.Interfaces;

namespace Task_Tracker_V4.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly MyDbContext _context;

        public LoginRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Login?> GetByEmailAsync(string email)
        {
            var l = await _context.Logins
                .Where(x => x.Email == email && x.StatusId != 2)
                .FirstOrDefaultAsync();
            return l;
        }
    }
}
