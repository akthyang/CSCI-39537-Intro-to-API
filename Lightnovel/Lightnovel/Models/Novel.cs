using System.Security.AccessControl;
using System.Text.Json.Serialization;

namespace LightNovel.Models
{
    public class Novel
    {
        public int NovelId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string OriginalLanguage { get; set; } = string.Empty;
        public string Blurb { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string BookStatus { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public int? CreatorId { get; set; }
        public Creator? Creator { get; set; }
        public int? ComicId { get; set; }
        public Comic? Comic { get; set; }
        public int? RawId { get; set; }
        public Raw? Raw { get; set; }

    }

}
