using AutoMapper;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.BLL.ViewModels;
using PhotoService.DAL.Entities;
using PhotoService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhotoService.BLL.Services
{
    public class SearchService : ISearchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private IEnumerable<ImageModel> _imageList { get => _mapper.Map<IList<ImageModel>> (_unitOfWork.ImageRepository.GetWithInclude(x=>x is Image,i=>i.User, i=>i.Hashtags)); }
        private IEnumerable<HashtagModel> _tagList;
        private IEnumerable<UserModel> _authorList;

        public SearchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            _tagList = _imageList.SelectMany(item => item.Hashtags).Distinct().ToList();
            _authorList = _imageList.Select(item => item.Author).Distinct().ToList();
        }

        public IEnumerable<SimpleImageViewModel> GetImagesByFilter(ImageFilterModel filter)
        {
            return _mapper.Map<IEnumerable<SimpleImageViewModel>>(_imageList.Where(image =>
            {
                var isCurrent = false;
                if(filter.Tag != null)
                {
                    isCurrent = image.Hashtags.Any(tag => tag.Title.ToUpper().Contains(filter.Tag.ToUpper()));
                }
                if(filter.Author != null)
                {
                    isCurrent = image.Author.UserName.ToUpper().Contains(filter.Author.ToUpper());
                }
                if(filter.Query != null)
                {
                    isCurrent = image.Title.ToUpper().Contains(filter.Query.ToUpper()) || image.Description.ToUpper().Contains(filter.Query.ToUpper());
                }

                return isCurrent;
            }));
        }

        public IEnumerable<SearchResultModel> GetResultsByFilter(string filter)
        {
            var filtredAuthors = _authorList.Where(author => author.UserName.Contains(filter));
            var filtredTags = _tagList.Where(tag => tag.Title.Contains(filter));

            List<SearchResultModel> results = new List<SearchResultModel>();
            results.AddRange(_mapper.Map<IEnumerable<SearchResultModel>>(filtredTags));
            results.AddRange(_mapper.Map<IEnumerable<SearchResultModel>>(filtredAuthors));
            if(filter.Length > 1)
            {
                foreach (var item in results)
                {
                    item.MatchPercent = SimilarityTool.CompareStrings(item.Text, filter);
                }
            }
            results.Sort((a, b) => a.MatchPercent.CompareTo(b.MatchPercent));
     
            return results;
        }
    }
}
