using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Exceptions;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.ViewModels;

namespace PhotoService.Controllers
{
    /// <summary>
    /// manages operations related to likes
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly IUserCollectionService _userCollectionService;

        public LikeController(IUserCollectionService userCollectionService)
        {
            _userCollectionService = userCollectionService;
        }


        /// <summary>
        /// endpoint to check if image is liked by user
        /// </summary>
        /// <param name="imageId">image id</param>
        /// <param name="userName">username</param>
        /// <returns>
        ///     if succeeded: 200 with boolean which shows is image liked or not
        ///     if failse: 400 with custom message / 500
        /// </returns>
        [HttpGet("isLiked")]
        public ActionResult CheckIfLiked([FromQuery] int imageId, [FromQuery] string userName)
        {
            try
            {

                var result = _userCollectionService.ChechIfIsLiked(userName, imageId);
                return Ok(result);
            }
            catch(CollectionException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// endpoint to like an image
        /// </summary>
        /// <param name="addLikeViewModel">model for adding like</param>
        /// <returns>
        ///     if succeeded: 200 
        ///     if fails: 400 with custom message / 500
        /// </returns>
        [HttpPost]
        public async Task<ActionResult> AddLike([FromBody] AddLikeViewModel addLikeViewModel)
        {
            try
            {
                await _userCollectionService.AddImageToCollection(
                    new AddImageToCollectionViewModel()
                    { 
                        CollectionName = "Likes",
                        ImageId = addLikeViewModel.ImageId,
                        Username = addLikeViewModel.Username
                    });

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
        /// endpoint to dislike an image
        /// </summary>
        /// <param name="addLikeViewModel">model for adding dislike</param>
        /// <returns>
        ///     if succeeded: 200 
        ///     if fails: 400 with custom message / 500
        /// </returns>
        [HttpPost("dislike")]
        public async Task<ActionResult> AddDislike([FromBody] AddLikeViewModel addLikeViewModel)
        {
            try
            {
                await _userCollectionService.RemoveImageFromCollection(
                    new AddImageToCollectionViewModel()
                    {
                        CollectionName = "Likes",
                        ImageId = addLikeViewModel.ImageId,
                        Username = addLikeViewModel.Username
                    });

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
    }
}
