using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Interfaces;

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

    }
}
