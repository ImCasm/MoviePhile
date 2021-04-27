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
        public Task<bool> SetFilmComment(FilmComment filmComment);


        /*
         * return commentarios de una pelicula especifica
         */
      public Task<IEnumerable<FilmComment>> GetAllComment(int IdFilm);
    }
}
