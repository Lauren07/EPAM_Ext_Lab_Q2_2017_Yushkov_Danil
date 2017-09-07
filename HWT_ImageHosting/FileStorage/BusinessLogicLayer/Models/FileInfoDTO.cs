using System;

namespace BusinessLogicLayer.Models
{
    public class FileInfoDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Content { get; set; }

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
