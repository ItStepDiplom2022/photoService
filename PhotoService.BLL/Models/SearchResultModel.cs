using PhotoService.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Models
{
    public class SearchResultModel
    {
        public string Text { get; set; }

        public SearchResultType Type { get; set; }

        public string? ImageUrl { get; set; }

        public float MatchPercent { get; set; } = 0.0f;
    }
}
