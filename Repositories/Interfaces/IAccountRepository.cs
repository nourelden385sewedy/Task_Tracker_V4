using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.Data.Models;

namespace Task_Tracker_V4.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(long id);
        Task<long?> GetIdByNameAsync(string? name);
        Task<string?> GetRoleNameByAccountIdAsync(long id);
        Task<string?> GetAccountNameByIdAsync(long id);
        Task<IEnumerable<AccountDto>> GetAllAsync();
        Task<Account?> GetByEmailAsync(string email);
        void Add(Account account);
        void Update(Account account);
        Task SaveChangesAsync();

    }
}
