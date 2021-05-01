using Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IGenreService
    {
        /// <summary>
        /// Obtiene los generos de las películas
        /// </summary>
        /// <returns>Una lista de generos</returns>
        Task<ICollection<Genre>> GetAllMovieGenres();

        /// <summary>
        /// Obtiene los generos de las series
        /// </summary>
        /// <returns>Una lista de generos</returns>
        Task<ICollection<Genre>> GetAllSeriesGenres();

        /// <summary>
        /// Obtiene todos los generos
        /// </summary>
        /// <returns>Una lista de generos</returns>
        Task<ICollection<Genre>> GetAllGenres();

        /// <summary>
        /// Obtiene un genero por su id
        /// </summary>
        /// <param name="id">id del genero a buscar</param>
        /// <returns>Objeto id si fue encontrado, de lo contrario null</returns>
        Task<Genre> GetGenreById(int id);
    }
}
