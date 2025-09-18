using Task_Tracker_V4.DTOs;
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

        public async Task<Account?> ValidateLoginAsync(LoginRequest log)
        {
            var login = await _loginRepo.GetByEmailAsync(log.Email);

            if (login != null && login.PasswordHash == log.Password)
            {

            }

            Account? account = null;

            return account;

        } 

    }
}
