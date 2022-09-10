using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Interfaces;

namespace PhotoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

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
    }
}
