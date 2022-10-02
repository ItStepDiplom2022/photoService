using PhotoService.BLL.Interfaces;
using PhotoService.DAL;
using PhotoService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Services
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Dislike(int imageId, string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsLiked(int imageId, string username)
        {
            var collection = _unitOfWork.CollectionRepository.GetWithInclude(c=>c.Owner.UserName == username && c.CollectionType.Title == "LIKES",i=>i.Images);

            return Task.FromResult(true);

        }

        public Task Like(int imageId, string username)
        {
            throw new NotImplementedException();
        }
    }
}
