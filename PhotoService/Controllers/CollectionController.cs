using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Exceptions;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.ViewModels;

namespace PhotoService.Controllers
{
    /// <summary>
    /// controller for managing collection operations
    /// </summary>
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
        /// endpoint for adding image to collection
        /// </summary>
        /// <param name="imageToCollectionModel">model with imageId, username and collectionName</param>
        /// <returns>
        ///     if succeeded: 200
        ///     if fails: 400 with custom message / 500
        /// </returns>
        [HttpPost("image")]
        public async Task<ActionResult> AddToCollection([FromBody] AddImageToCollectionViewModel imageToCollectionModel)
        {
            try
            {
                await _userCollectionService.AddImageToCollection(imageToCollectionModel);
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

        /// <summary>
        /// endpoint for getting collections by username
        /// </summary>
        /// <param name="username">username, whose collection to get</param>
        /// <param name="publicOnly">boolean which shows to get only public collections or not</param>
        /// <returns>
        ///     if succeeded: 200 with collection of collection models
        ///     if fails: 500
        /// </returns>
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

        /// <summary>
        /// endpoint for creating new collection
        /// </summary>
        /// <param name="model">model with necessary properties for adding collection</param>
        /// <returns>
        ///     if succeeded: 200 with added collection
        ///     if fails: 500 
        /// </returns>
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
