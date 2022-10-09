using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Exceptions;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.ViewModels;

namespace PhotoService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController:ControllerBase
    {
        private readonly IUserCollectionService _userCollectionService;
        public CollectionController(IUserCollectionService userCollectionService)
        {
            _userCollectionService = userCollectionService;
        }

        /// <summary>
        /// adds image to collection
        /// </summary>
        [HttpPost("image")]
        public async Task<ActionResult> AddToCollection([FromBody] AddImageToCollectionViewModel model)
        {
            try
            {
                await _userCollectionService.AddImageToCollection(model);
                return Ok();
            }
            catch (CollectionException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetCollections([FromQuery] string username, [FromQuery] bool publicOnly)
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

        [HttpPost]
        public async Task<ActionResult> CreateNewCollection([FromBody] CollectionCreateViewModel model)
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
    }
}
