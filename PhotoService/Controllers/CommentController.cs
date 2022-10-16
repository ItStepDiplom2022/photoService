using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.ViewModels;

namespace PhotoService.Controllers
{
    /// <summary>
    /// controller to manage actions related to comments
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IImageService _imageService;

        public CommentController(ICommentService commentService, IImageService imageService)
        {
            _commentService = commentService;
            _imageService = imageService;
        }

        /// <summary>
        /// endpoint to get comments by image id
        /// </summary>
        /// <param name="id">image id</param>
        /// <returns>
        ///     if succeeded: 200 with collection of comments
        ///     if fails: 500
        /// </returns>
        [AllowAnonymous]
        [HttpGet("{id:}")]
        public ActionResult GetCommentsByImageId(int id)
        {
            try
            {
                var comments = _commentService.RetrieveComments(id).OrderByDescending(p=>p.DateAdded);

                return Ok(comments);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// endpoint to get commnets to image
        /// </summary>
        /// <param name="commentAddViewModel">model with CommentText, ImageId and username</param>
        /// <returns>
        ///     if succeeded: 200
        ///     if failse: 500
        /// </returns>
        [HttpPost]
        public async Task<ActionResult> PostCommentToImage([FromBody] CommentAddViewModel commentAddViewModel)
        {
            try
            {
                await _imageService.AddComment(commentAddViewModel);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
