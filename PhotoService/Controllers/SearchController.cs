using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;

namespace PhotoService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] string? author, [FromQuery] string? tag, [FromQuery] string? q)
        {
            if (author == null && tag == null && q == null)
                return Ok(_searchService.GetImagesByFilter(new ImageFilterModel()));

            var filter = new ImageFilterModel() { Author = author, Tag = tag, Query = q };

            return Ok(_searchService.GetImagesByFilter(filter));
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult Filter([FromQuery]string filter = "")
        {
            return Ok(_searchService.GetResultsByFilter(filter));
        }
    }
}
