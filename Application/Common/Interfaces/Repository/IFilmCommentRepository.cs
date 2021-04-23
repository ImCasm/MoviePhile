using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Common.Interfaces.Repository
{
    public  interface IFilmCommentRepository : IRepository<FilmComment>
    {
        Task<bool> SetFilmComment(FilmComment filmComment);
    }
}
