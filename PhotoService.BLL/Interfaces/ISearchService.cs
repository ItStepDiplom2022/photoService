using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;

namespace PhotoService.BLL.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<SearchResultModel> GetResultsByFilter(string filter);

        IEnumerable<SimpleImageViewModel> GetImagesByFilter(ImageFilterModel filter);
    }
}
