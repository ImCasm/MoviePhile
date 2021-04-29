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

        /// <summary>
        ///  Almacena un comentario en la base de datos
        /// </summary>
        /// <param name="filmComment">Comentario con datos necesarios para ser almacenado</param>
        /// <returns>true si se almacena sin errores, false en otro caso</returns>
        public Task<bool> SetFilmComment(FilmComment filmComment);


        /// <summary>
        /// Obtiene Todos los comentarios de una pelicula
        /// </summary>
        /// <param name="IdFilm">Número de página a buscar</param>
        /// <returns>Lista de Comentarios en formato JSON</returns>
        public Task<IEnumerable<FilmComment>> GetAllComment(int IdFilm);
    }
}
