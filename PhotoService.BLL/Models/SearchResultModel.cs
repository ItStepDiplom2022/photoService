using PhotoService.BLL.Enums;

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
