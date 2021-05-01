using System.Collections.Generic;

namespace Application.Dto
{
    public class CommunityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
        public ICollection<PublicationDto> Publications { get; set; }
        public ICollection<UserDto> Users { get; set; }
    }
}
