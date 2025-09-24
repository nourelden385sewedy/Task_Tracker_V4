using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.HelperClasses;
using Task_Tracker_V4.Data.Models;
using Task_Tracker_V4.Repositories.Interfaces;
using Task_Tracker_V4.Services.Interfaces;

namespace Task_Tracker_V4.Services
{
    public class LoginService
    {
        private readonly ILoginRepository _loginRepo;
        private readonly IAccountRepository _accountRepo;
        private readonly IRoleMapper _roleMapper;

        public LoginService(ILoginRepository loginRepo, IAccountRepository accountRepo, IRoleMapper roleMapper)
        {
            _loginRepo = loginRepo;
            _accountRepo = accountRepo;
            _roleMapper = roleMapper;
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
                    RoleHash = _roleMapper.MapToRole(acc.RoleId),
                    JoinDate = acc.CreatedAt
                };
                return account;
            }

            return null;
        } 

    }
}
