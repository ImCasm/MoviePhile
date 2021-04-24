using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        /// <summary>
        /// Obtiene una película por id desde la base de datos.
        /// Se utiliza en el caso de que la película esté referenciada a otra entidad,
        /// como por ejemplo comentarios o publicidades.
        /// </summary>
        /// <param name="id">Id de la película</param>
        /// <returns>La película encontrada</returns>
        Task<Movie> GetMovieById(int id);

        /// <summary>
        /// Permite guardar una película en la base de datos.
        /// Eso sucede en el caso que existan relaciones de comentarios o publicidades de esa película
        /// </summary>
        /// <param name="movie">Objeto de película que se va a guardar</param>
        /// <returns>La película guardada en la base de datos</returns>
        Task<Movie> InsertMovie(Movie movie);
    }
}
