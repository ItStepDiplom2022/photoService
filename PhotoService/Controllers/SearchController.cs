using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;

namespace PhotoService.Controllers
{
    /// <summary>
    /// manages image search operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        /// <summary>
        /// gets images by filter model
        /// </summary>
        /// <param name="author">username</param>
        /// <param name="tag">image tag</param>
        /// <param name="q">query to search in title</param>
        /// <param name="last">number of last fetched image</param>
        /// <param name="count">number of images to fetch</param>
        /// <returns>
        ///     collection of filtered images
        /// </returns>
        [HttpGet]
        public IActionResult FindImages([FromQuery] string? author, [FromQuery] string? tag, [FromQuery] string? q, [FromQuery] int last, [FromQuery] int count)
        {
            if (last < 0)
                return BadRequest();
            IEnumerable<SimpleImageViewModel> res;
            if (author == null && tag == null && q == null)
            {
                res = _searchService.GetImagesByFilter(new ImageFilterModel());
            }
            else
            {
                var filter = new ImageFilterModel() { Author = author, Tag = tag, Query = q };
                res = _searchService.GetImagesByFilter(filter);
            }
            if (last > res.Count())
                return BadRequest();

            var itemsCount = Math.Max(0, Math.Min(count, res.Count() - last));
            res = res.ToList().GetRange(last, itemsCount);
            return Ok(new {Items=res, Last=last+itemsCount, IsLast=(itemsCount < count && count != 0)});
        }

        /// <summary>
        /// get images by string filter
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>
        ///     collection of filtered images
        /// </returns>
        [HttpGet]
        [Route("filter")]
        public IActionResult Filter([FromQuery]string filter = "")
        {
            return Ok(_searchService.GetResultsByFilter(filter));
        }
    }
}
