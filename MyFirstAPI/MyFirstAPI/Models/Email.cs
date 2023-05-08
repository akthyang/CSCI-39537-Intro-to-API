using System;
namespace MyFirstAPI.Models
{
    public class Email
    {
        public int EmailId { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public bool isSubscribed { get; set; }
    }
}
