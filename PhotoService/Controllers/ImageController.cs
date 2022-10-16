using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Exceptions;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;

namespace PhotoService.Controllers
{
    /// <summary>
    /// manages all operations related to image
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IUserCollectionService _userCollectionService;
        public ImageController(IImageService imageService, IUserCollectionService userCollectionService)
        {
            _imageService = imageService;
            _userCollectionService = userCollectionService;
        }

        /// <summary>
        /// endpoint to get image by its id
        /// </summary>
        /// <param name="id">image id</param>
        /// <returns>
        ///     if succeeded: 200 with image model
        ///     if fails: 500
        /// </returns>
        [AllowAnonymous]
        [HttpGet("{id:}")]
        public ActionResult GetImage(int id)
        {
            try
            {
                var image =  _imageService.GetImage(id);

                return Ok(image);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// endpoint to get images by user email
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>
        ///     if succeeded: 200 with collection of images
        ///     if fails: 500
        /// </returns>
        [AllowAnonymous]
        [HttpGet("email/{email:}")]
        public ActionResult GetImagesByEmail(string email)
        {
            try
            {
                var image = _imageService.GetImagesByUserEmail(email);
                return Ok(image);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// endpoint to get images by username
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>
        ///     if succeeded: 200 with collection of images
        ///     if fails: 500
        /// </returns>
        [AllowAnonymous]
        [HttpGet("username/{username:}")]
        public ActionResult GetImagesByUserName(string username)
        {
            try
            {
                var images = _imageService.GetImagesByUserName(username);
                return Ok(images);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// endpoint for adding an image
        /// </summary>
        /// <param name="image">image model to add</param>
        /// <returns>
        ///     if succeeded: 200 with added image
        ///     if fails: 400 with custom message / 500
        /// </returns>
        [HttpPost]
        public async Task<ActionResult> PostImage([FromBody] ImageAddModel image)
        {
            try
            {
                var addedImage=await _imageService.AddImage(image);
                return Ok(addedImage);
            }
            catch(BlobException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// endpoint to get images by collection
        /// </summary>
        /// <param name="username">collection owner</param>
        /// <param name="collectionName">collection name</param>
        /// <returns>
        ///     if succeeded: 200 with collection of images
        ///     if fails: 400 with custom message / 500
        /// </returns>
        [AllowAnonymous]
        [HttpGet("collection/{username:}")]
        public async Task<ActionResult> GetImagesByCollection(string username, [FromQuery] string collectionName)
        {
            try
            {
                var result = _userCollectionService.GetCollection(username,collectionName);
                return Ok(result);
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

    }
}
