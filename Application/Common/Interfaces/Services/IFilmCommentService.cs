﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IFilmCommentService
    {
       public Task<bool> SetComment(FilmComment filmComment);

    }
}
