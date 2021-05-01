using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IGenreRepository : IRepository<Genre>
    {
        /// <summary>
        /// Inserta un genero en la base de datos
        /// </summary>
        /// <param name="genre">Genero a insertar</param>
        /// <returns>El objeo genero si se inserto, lanza una excepcion de lo contrario</returns>
        Task<Genre> InsertGenre(Genre genre);

        /// <summary>
        /// Obtiene la lista de generos en la base de datos
        /// </summary>
        /// <returns>Lista de generos obtenidos</returns>
        Task<ICollection<Genre>> GetGenres();
    }
}
