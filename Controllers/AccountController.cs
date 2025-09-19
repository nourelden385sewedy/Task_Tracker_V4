using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Tracker_V4.DTOs;
using Task_Tracker_V4.Services;

namespace Task_Tracker_V4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet("users")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllUsersAsync();
            if (accounts == null)
            {
                return NotFound("There is no Users right now");
            }
            return Ok(accounts);
        }


        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetAccountById(long id)
        {
            var account = await _accountService.GetUserById(id);
            if (account == null)
            {
                return NotFound("Something went wrong, this account not found");
            }
            return Ok(account);
        }


        [HttpPatch("update-role/{id}/{roleHash}")]
        public async Task<IActionResult> UpdateAccountRoleAsync(long id, string roleHash)
        {
            bool isStatusUpdated = await _accountService.ChangeAccountRoleAsync(id, roleHash);

            if (!isStatusUpdated)
            {
                return NotFound("There is something went wrong, can't update the Role");
            }

            return Ok("Role Updated Successfully");
        }


        [HttpPut("update")]
        public async Task<IActionResult> UpdateAccountAsync(AccountDto accDto)
        {
            bool isUpdated = await _accountService.UpdateAccountAsync(accDto);

            if (!isUpdated)
            {
                return BadRequest("the Account didn't Updated, there is something wrong");
            }

            return Ok("Account Updated Successfully");
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAccountAsync(long id)
        {
            bool isDeleted = await _accountService.DeleteAccountAsync(id);
            if (!isDeleted)
            {
                return NotFound("Account don't exist, can't delete it");
            }
            return Ok("Account Deleted Successfully");
        }
    }
}
