﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class PublicationDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public ICollection<PublicationCommentDTO> Comments { get; set; }
        public UserDTO User { get; set; }
    }
}