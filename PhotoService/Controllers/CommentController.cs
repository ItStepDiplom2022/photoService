using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.ViewModels;

namespace PhotoService.Controllers
{
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

        [HttpPost]
        public async Task<ActionResult> PostCommentToImage([FromBody] CommentAddViewModel image)
        {
            try
            {
                await _imageService.AddComment(image);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
