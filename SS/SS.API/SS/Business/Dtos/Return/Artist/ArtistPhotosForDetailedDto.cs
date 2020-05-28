using System;

namespace SS.Business.Dtos.Return
{
    public class ArtistPhotosForDetailedDto
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string PhotoDescription { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}