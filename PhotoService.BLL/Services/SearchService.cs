using AutoMapper;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;
using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;

namespace PhotoService.BLL.Services
{
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private IEnumerable<ImageModel> _imageList { get => _mapper.Map<IList<ImageModel>> (_unitOfWork.ImageRepository.GetWithInclude(x=>x is Image,i=>i.User, i=>i.Hashtags)); }
        private IEnumerable<HashtagModel> _tagList { get => _mapper.Map<IList<HashtagModel>>(_unitOfWork.HashTagRepository.GetHashTags()); }
        private IEnumerable<UserModel> _authorList { get => _mapper.Map<IList<UserModel>>(_unitOfWork.UserRepository.GetUsers()); }

        public SearchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<SimpleImageViewModel> GetImagesByFilter(ImageFilterModel filter)
        {
            return _mapper.Map<IEnumerable<SimpleImageViewModel>>(_imageList.Where(image =>
            {
                if(filter.Query != null)
                {
                    filter.Tag = filter.Query;
                    filter.Author = filter.Query;
                }

                var isCurrent = false;
                if(filter.Tag != null && !isCurrent)
                {
                    isCurrent = image.Hashtags.Any(tag => tag.Title.ToUpper().Contains(filter.Tag.ToUpper()));
                }
                if(filter.Author != null && !isCurrent)
                {
                    isCurrent = image.Author.UserName.ToUpper().Contains(filter.Author.ToUpper());
                }
                if(filter.Query != null && !isCurrent)
                {
                    isCurrent = image.Title.ToUpper().Contains(filter.Query.ToUpper()) || image.Description.ToUpper().Contains(filter.Query.ToUpper());
                }

                return isCurrent;
            }));
        }

        public IEnumerable<SearchResultModel> GetResultsByFilter(string filter)
        {
            bool isTag = false;

            string searchWord = filter;
            if(searchWord.StartsWith('#'))
            {
                isTag = true;
                searchWord = searchWord.Substring(1);
            }

            IEnumerable<UserModel> filtredAuthors = new List<UserModel>();
            if(!isTag)
            {
                filtredAuthors = _authorList.Where(author => author.UserName.Contains(searchWord));
            }
            var filtredTags = _tagList.Where(tag => tag.Title.Contains(searchWord));

            List<SearchResultModel> results = new List<SearchResultModel>();
            results.AddRange(_mapper.Map<IEnumerable<SearchResultModel>>(filtredTags));
            results.AddRange(_mapper.Map<IEnumerable<SearchResultModel>>(filtredAuthors));
            if(searchWord.Length > 1)
            {
                foreach (var item in results)
                {
                    item.MatchPercent = SimilarityTool.CompareStrings(item.Text, searchWord);
                }
            }
            results.Sort((a, b) => a.MatchPercent.CompareTo(b.MatchPercent));
     
            return results;
        }
    }
}
