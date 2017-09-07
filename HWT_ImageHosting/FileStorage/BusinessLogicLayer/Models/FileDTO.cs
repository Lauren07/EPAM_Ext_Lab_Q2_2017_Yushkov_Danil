using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Models
{
    public class FileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPublic { get; set; }
        public IEnumerable<int> RolesId { get; set; }
        public User User { get; set; }

        public string ImageSource
        {
            get
            {
                var mimeType = "image/jpg";
                var base64 = Convert.ToBase64String(Content);
                return $"data:{mimeType};base64,{base64}";
            }
        }
    }
}
