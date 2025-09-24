using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.HelperClasses;
using Task_Tracker_V4.Repositories;
using Task_Tracker_V4.Data.Models;

namespace Task_Tracker_V4.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepo;
        private readonly IRoleMapper _roleMapper;

        public AccountService(AccountRepository accountRepo, IRoleMapper roleMapper)
        {
            _accountRepo = accountRepo;
            _roleMapper = roleMapper;
        }


        public async Task<IEnumerable<AccountDto>> GetAllUsersAsync()
        {
            var accounts = await _accountRepo.GetAllAsync();
            return accounts;
        }

        public async Task<AccountDto?> GetUserById(long id)
        {
            var account = await _accountRepo.GetByIdAsync(id);

            if (account != null)
            {
                AccountDto accountDto = new AccountDto()
                {
                    Id = account.Id,
                    Name = account.FullNameEn,
                    Email = account.Email,
                    Phone = account.Phone,
                    RoleHash = _roleMapper.MapToRole(account.RoleId),
                    JoinDate = account.CreatedAt
                };
                return accountDto;
            }

            return null; 
        }

        public async Task<bool> ChangeAccountRoleAsync(long id, string roleHash)
        {
            var acc = await _accountRepo.GetByIdAsync(id);

            if (acc == null)
            {
                return false;
            }
            
            acc.RoleId = _roleMapper.MapToRoleID(roleHash);
            _accountRepo.Update(acc);
            await _accountRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAccountAsync(AccountDto accountDto)
        {
            var acc = await _accountRepo.GetByIdAsync(accountDto.Id);

            if (acc == null)
            {
                return false;
            }

            acc.FullNameEn = accountDto.Name;
            acc.Email = accountDto.Email;
            acc.Phone = accountDto.Phone;
            acc.RoleId = _roleMapper.MapToRoleID(accountDto.RoleHash);

            _accountRepo.Update(acc);
            await _accountRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAccountAsync(long id)
        {
            var acc = await _accountRepo.GetByIdAsync(id);

            if (acc == null)
            {
                return false;
            }

            acc.IsActive = false;
            _accountRepo.Update(acc);
            await _accountRepo.SaveChangesAsync();

            return true;
        }




    }
}
