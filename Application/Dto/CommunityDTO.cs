﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CommunityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
        public ICollection<PublicationDto> Publications { get; set; }
        public ICollection<UserDto> Users { get; set; }
    }
}
