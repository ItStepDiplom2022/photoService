using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;

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
                var image = _imageService.GetImage(id);
                return Ok(image);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult PostImage([FromBody] ImageAddModel image)
        {
            try
            {
                var addedImage=_imageService.AddImage(image);
                return Ok(addedImage);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
