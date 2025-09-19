using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.HelperClasses;
using Task_Tracker_V4.Models;
using Task_Tracker_V4.Repositories.Interfaces;
using Task_Tracker_V4.Services.Interfaces;

namespace Task_Tracker_V4.Services
{
    public class LoginService
    {
        private readonly ILoginRepository _loginRepo;
        private readonly IAccountRepository _accountRepo;

        public LoginService(ILoginRepository loginRepo, IAccountRepository accountRepo)
        {
            _loginRepo = loginRepo;
            _accountRepo = accountRepo;
        }

        public async Task<AccountDto?> ValidateLoginAsync(LoginRequest log)
        {
            var login = await _loginRepo.GetByEmailAsync(log.Email);

            if (login != null && login.PasswordHash == log.Password)
            {
                var acc = await _accountRepo.GetByIdAsync(login.AccountId);
                AccountDto account = new AccountDto()
                {
                    Id = acc.Id,
                    Name = acc.FullNameEn,
                    Email = acc.Email,
                    Phone = acc.Phone,
                    RoleHash = RoleMapper.MapIdToRoleHash(acc.RoleId),
                    JoinDate = acc.CreatedAt
                };
                return account;
            }

            return null;
        } 

    }
}
