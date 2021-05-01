using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IMovieService
    {
        /// <summary>
        /// Obtiene un JSON con una lista de películas según su nombre
        /// </summary>
        /// <param name="query">Filtro del nombre de la película</param>
        /// <param name="page">Página de la lista que se quiere obtener</param>
        /// <returns>Lista en formato JSON</returns>
        Task<string> GetMoviesByName(string query, int page = 1);

        /// <summary>
        /// Obtiene una lista de las películas más populares del momento
        /// </summary>
        /// <param name="page">Número de la página que se quiere obtener</param>
        /// <returns>La lista de películas en formato JSON</returns>
        Task<string> GetPopularMovies(int page = 1);

        /// <summary>
        /// Obtiene una película por su Id.
        /// Caso 1. Si existe en la base de datos, la retorna con sus relaciones,
        /// como por ejemplo los comentarios de esa película
        /// Caso 2. Si no existe en la base de datos llama al cliente http para traerla desde el API externa,
        /// adicionalmente la convierte de objeto JSON a una entidad del negocio
        /// </summary>
        /// <param name="id">Id de la película</param>
        /// <returns>El objeto de la película encontrada</returns>
        Task<Movie> GetMovieById(int id);

       /// <summary>
       /// Permite guardar una película por medio del repositorio de datos
       /// </summary>
       /// <param name="movie">Película que se va a guardar</param>
       /// <returns>Película encontrada</returns>
        Task<Movie> InsertMovie(Movie movie);

        /// <summary>
        /// Verifica si la pelicula con un id dado existe en la base de datos
        /// </summary>
        /// <param name="id">Id de la película a verificar</param>
        /// <returns>true si existe en la base de datos, false en otro caso</returns>
        Task<bool> ExistMovieOnDb(int id);
    }
}
