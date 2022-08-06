using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<SearchResultModel> GetResultsByFilter(string filter);

        IEnumerable<SimpleImageViewModel> GetImagesByFilter(ImageFilterModel filter);
    }
}
