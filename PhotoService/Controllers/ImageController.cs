using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;

namespace PhotoService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

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

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PostImage([FromBody] ImageAddModel image)
        {
            try
            {
                var addedImage=await _imageService.AddImage(image);
                return Ok(addedImage);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("comment")]
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
