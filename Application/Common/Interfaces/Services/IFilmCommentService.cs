using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IFilmCommentService
    {

        /*
         * Almacenar un comentario en la base de datos
         */
        public Task<bool> SetComment(FilmComment filmComment);


        /*
         *Todos los comentarios almacenados en la base de datos refentes a una pelicula especifica 
         */
        public Task<IEnumerable<FilmComment>> GetAllComment(int IdFilm);

    }
}
