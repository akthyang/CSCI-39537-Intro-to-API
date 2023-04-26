using System;
using LightNovel.Models;
using Microsoft.EntityFrameworkCore;

namespace Lightnovel.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public List<Novel> novels { get; set; } = new();
    }
}
