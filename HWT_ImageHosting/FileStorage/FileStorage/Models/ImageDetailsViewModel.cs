using System;

namespace FileStorage.Models
{
    public class ImageDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public string ImageSource { get; set; }
    }
}