using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.ViewModels;

namespace PhotoService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IUserCollectionService _userCollectionService;
        private readonly IUserService _userService;

        public ProfileController(IUserCollectionService userCollectionService, IUserService userService)
        {
            _userCollectionService = userCollectionService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("collections")]
        public ActionResult GetCollections([FromQuery]string username, [FromQuery] bool publicOnly)
        {
            try
            {
                var collections = _userCollectionService.GetCollections(username, publicOnly);
                return Ok(collections);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("collections/create")]
        public async Task<ActionResult> CreateNewCollection([FromBody]CollectionCreateViewModel model)
        {
            try
            {
                var collection = await _userCollectionService.CreateCollection(model.Username, model.CollectionName, model.IsPublic);
                return Ok(collection);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("user")]
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
