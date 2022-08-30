using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Exceptions;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.EmailTemplates;
using PhotoService.Renderes;

namespace PhotoService.Controllers
{
    /// <summary>
    /// this controller manages account operations
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IHtmlRenderer _htmlRenderer;
        private readonly IEmailService _emailService;
        private readonly string _key;

        public AccountController(IUserService userService, IJwtService jwtService, IEmailService emailService, IConfiguration configuration, IHtmlRenderer htmlRenderer)
        {
            _userService = userService;
            _jwtService = jwtService;
            _emailService = emailService;
            _htmlRenderer = htmlRenderer;
            _key = configuration.GetSection("JwtKey").ToString();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login(UserLoginModel userModel)
        {
            try
            {
                var username = _userService.GetUserByEmail(userModel.Email).UserName;
                var token = _userService.Autheticate(userModel.Email, userModel.Password);

                return Ok(new { token, email = userModel.Email, username = username });
            }
            catch (AuthorizationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult> Signup(UserRegisterModel user)
        {
            try
            {
                var htmlBody = await _htmlRenderer.RenderEmail(new VerificationEmailModel { Email = user.Email, UserName = user.UserName });

                await _userService.Create(user);
                await _emailService.SendEmail(user.Email, "PHOTO SERVICE EMAIL VERIFICATION", htmlBody);
                return Ok(new { email = user.Email });
            }
            catch (AuthorizationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// verifies user email
        /// </summary>
        /// <param name="email">email to verify</param>
        /// <returns>if succeeded: 200
        ///          if email is not registered: 400
        /// </returns>
        [AllowAnonymous]
        [HttpGet("verify")]
        public async Task<ActionResult> VerifyEmail([FromQuery] string email)
        {
            try
            {
                var htmlBody = await _htmlRenderer.RenderEmail(new SuccessfulVerificationModel { Email = email });

                await _userService.VerifyUser(email);
                await _emailService.SendEmail(email, "PHOTO SERVICE EMAIL VERIFICATION SUCCESSFUL", htmlBody);
                return Ok("Your email was successfuly verified");
            }
            catch (AuthorizationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                return Ok(_userService.GetUsers());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


    }
}
