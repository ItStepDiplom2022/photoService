using Microsoft.AspNetCore.Mvc;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;
using System.Collections.Generic;

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
        public IActionResult Index([FromQuery] string? author, [FromQuery] string? tag, [FromQuery] string? q, [FromQuery] int last, [FromQuery] int count)
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

        [HttpGet]
        [Route("filter")]
        public IActionResult Filter([FromQuery]string filter = "")
        {
            return Ok(_searchService.GetResultsByFilter(filter));
        }
    }
}
