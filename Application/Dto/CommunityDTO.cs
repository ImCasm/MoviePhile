using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CommunityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<PublicationDTO> Publications { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}
