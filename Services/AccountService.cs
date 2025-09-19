using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.HelperClasses;
using Task_Tracker_V4.Repositories;

namespace Task_Tracker_V4.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepo;

        public AccountService(AccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }


        public async Task<bool> ChangeAccountRoleAsync(long id, string roleHash)
        {
            var acc = await _accountRepo.GetByIdAsync(id);

            if (acc == null)
            {
                return false;
            }
            
            acc.RoleId = RoleMapper.MapRoleHashToId(roleHash);
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
            acc.RoleId = RoleMapper.MapRoleHashToId(accountDto.RoleHash);

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

            return true;
        }




    }
}
