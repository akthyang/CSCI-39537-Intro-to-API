namespace LightNovel.Models
{
    public class Creator
    {
        public int CreatorId { get; set; }
        public string EnglishFirstName { get; set; } = string.Empty;
        public string EnglishLastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
