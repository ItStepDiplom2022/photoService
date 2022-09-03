using PhotoService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.DAL.Interfaces
{
    public interface IHashTagRepository
    {
        Hashtag GetHashTagByTitle(string title);
    }
}
