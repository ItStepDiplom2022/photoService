using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Exceptions;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.EmailTemplates;
using PhotoService.Renderes;

namespace PhotoService.Controllers
{
    /// <summary>
    ///  manages user account operations
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHtmlRenderer _htmlRenderer;
        private readonly IEmailService _emailService;

        public AccountController(IUserService userService, IEmailService emailService, IHtmlRenderer htmlRenderer)
        {
            _userService = userService;
            _emailService = emailService;
            _htmlRenderer = htmlRenderer;
        }

        /// <summary>
        /// endpoint for user login
        /// </summary>
        /// <param name="userModel">model with user email and password</param>
        /// <returns>
        ///     if succeded: 200 with token, username, and email
        ///     if failed: 400 with custom error message / 500
        /// </returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login(UserLoginModel userModel)
        {
            try
            {
                var token = _userService.Autheticate(userModel.Email, userModel.Password);
                var username = _userService.GetUserByEmail(userModel.Email).UserName;

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

        /// <summary>
        /// endpoint for user signup (also authomatically sends and email for verification)
        /// </summary>
        /// <param name="user">model with user email, username and password</param>
        /// <returns>
        ///     if succeded: 200 with user email
        ///     if failed: 400 with custom error message / 500
        /// </returns>
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
        /// endpoint to verify user email
        /// </summary>
        /// <param name="email">email to verify</param>
        /// <returns>
        ///     if succeeded: 200
        ///     if email is not registered: 400
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

        /// <summary>
        /// endpoint for getting all users
        /// </summary>
        /// <returns>
        ///     if succeded: 200 with collection of user models
        ///     if fails: 500
        /// </returns>
        [HttpGet("all")]
        public ActionResult GetAllUsers()
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

        /// <summary>
        /// endpoint to get userinfo
        /// </summary>
        /// <param name="username">username to find</param>
        /// <returns>
        ///     if succeded: 200 with user model
        ///     if fails: 500
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetUser([FromQuery] string username)
        {
            try
            {
                var user = _userService.GetUserByUsername(username);
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
