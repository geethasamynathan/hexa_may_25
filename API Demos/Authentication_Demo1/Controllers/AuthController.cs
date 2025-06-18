using Authentication_Demo1.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Authentication_Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration; 
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user=await _userManager.FindByNameAsync(loginModel.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["jwt:ValidIssuer"],
                    audience: _configuration["jwt:ValidAudience"],
                    expires: DateTime.Now.AddMinutes(30),
                    claims:authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256)
                    ) ;
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo

                });

            }
            return Unauthorized();

        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var userExists = await _userManager.FindByNameAsync(registerModel.Username);
            if(userExists != null) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", StatusMessage = "User Already Exisits" });
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = registerModel.Email,
                UserName = registerModel.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result=await _userManager.CreateAsync(user,registerModel.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", StatusMessage = "User Creation Failed1.." }
                    );
            }

            if(registerModel.Role=="admin")
            {
                if(!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Admin);

                }

            }
            if (registerModel.Role=="user")
            {
                if(!await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                if (await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.User);

                }
            }
            return Ok(new Response { Status = "Success", 
                StatusMessage = "User created successfully" });
            
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest(new { message = "Invalid Email Address" });

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // In a real-world app, this token would be sent via email.
            // For now, return it directly for testing/demo purposes
            var encodedToken = System.Net.WebUtility.UrlEncode(token);

            var resetLink = Url.Action(nameof(ResetPassword), "Auth", new { email = model.Email, token = encodedToken }, Request.Scheme);

            return Ok(new
            {
                Status = "Success",
                Message = "Password reset token generated successfully.",
                ResetLink = resetLink
            });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest(new { message = "User not found." });

            var decodedToken = System.Net.WebUtility.UrlDecode(model.Token);
            var result = await _userManager.ResetPasswordAsync(user, decodedToken, model.NewPassword);

            if (!result.Succeeded)
                return BadRequest(new
                {
                    message = "Password reset failed",
                    errors = result.Errors.Select(e => e.Description)
                });

            return Ok(new { Status = "Success", Message = "Password has been reset successfully" });
        }

    }
}

