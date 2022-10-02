using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Exceptions;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.ViewModels;

namespace PhotoService.Controllers
{
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
        /// checks if image is liked by user
        /// </summary>
        [AllowAnonymous]
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
        /// adds image to collection
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AddLike([FromBody] AddLikeViewModel model)
        {
            try
            {
                await _userCollectionService.AddImageToCollection(
                    new AddImageToCollectionViewModel()
                    { 
                        CollectionName = "Likes",
                        ImageId = model.ImageId,
                        Username = model.Username
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
        /// adds image to collection
        /// </summary>
        [AllowAnonymous]
        [HttpPost("dislike")]
        public async Task<ActionResult> AddDislike([FromBody] AddLikeViewModel model)
        {
            try
            {
                await _userCollectionService.RemoveImageFromCollection(
                    new AddImageToCollectionViewModel()
                    {
                        CollectionName = "Likes",
                        ImageId = model.ImageId,
                        Username = model.Username
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
