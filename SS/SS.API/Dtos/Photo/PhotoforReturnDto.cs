using System;

namespace SS.API.Dtos.Photo
{
    public class PhotoforReturnDto
    {
        public int Id { get; set; }
        public string PhotoDescription { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}