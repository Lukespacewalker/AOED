using System.Linq;
using System.Threading.Tasks;
using DoctorSystem.Shared.Model;
using DoctorSystem.Shared.Model.Authentication;
using DoctorSystem.Shared.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DoctorSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        //private static UserModel LoggedOutUser = new UserModel { IsAuthenticated = false };

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountsController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterModel model)
        {
            // Check InvitationKey
            if (model?.InvitationKey != _configuration["InvitationKey"])
            {
                return BadRequest(new RegisterResult { Successful = false, Errors = new [] {"รหัสคำเชิญไม่ถูกต้อง"} });
            }

            var newUser = new ApplicationUser { UserName = model.Username, Email = model.Email };

            var result = await _userManager.CreateAsync(newUser, model.Password).ConfigureAwait(false);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return BadRequest(new RegisterResult { Successful = false, Errors = errors });
            }

            return Ok(new RegisterResult { Successful = true });
        }
    }
}