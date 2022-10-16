using AutoMapper;
using PhotoService.BLL.Interfaces;
using PhotoService.BLL.Models;
using PhotoService.DAL.Interfaces;

namespace PhotoService.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<CommentModel> RetrieveComments(int imageId)
        {
            return _mapper.Map<IEnumerable<CommentModel>>(_unitOfWork.CommentRepository.GetWithInclude(x=>x.Image.Id==imageId,i=>i.UserAdded, i=> i.Image));
        }
    }
}
