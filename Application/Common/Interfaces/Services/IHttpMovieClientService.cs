using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IHttpMovieClientService
    {
        /// <summary>
        /// Obtiene una lista películas por su nombre
        /// </summary>
        /// <param name="query">Cadena de busqueda</param>
        /// <param name="page">Número de página a buscar</param>
        /// <returns>Lista de películas en formato JSON</returns>
        Task<string> GetMoviesByName(string query, int page);

        /// <summary>
        /// Obtiene la lista de películas populares
        /// </summary>
        /// <param name="page">Número de la página a buscar</param>
        /// <returns>Lista de películas en formato JSON</returns>
        Task<string> GetPopularMovies(int page);

        /// <summary>
        /// Obtiene una película por su Id
        /// </summary>
        /// <param name="id">Id de la película</param>
        /// <returns>La película encontrada</returns>
        Task<string> GetMovieById(int id);

        /// <summary>
        /// Obtiene una lista de series por su nombre
        /// </summary>
        /// <param name="query">Cadena de busqueda</param>
        /// <param name="page">Número de página a buscar</param>
        /// <returns>Lista de series en formato JSON</returns>
        Task<string> GetSeriesByName(string query, int page);

        /// <summary>
        /// Obtiene la lista de series populares
        /// </summary>
        /// <param name="page">Número de la página a buscar</param>
        /// <returns>Lista de series en formato JSON</returns>
        Task<string> GetPopularSeries(int page);

        /// <summary>
        /// Obtiene una serie por su Id
        /// </summary>
        /// <param name="id">Id de la serie</param>
        /// <returns>La serie encontrada</returns>
        Task<string> GetSerieById(int id);

        /// <summary>
        /// Obtiene la lista de generos de las peliculas
        /// </summary>
        /// <returns>Lista de generos en formato JSON</returns>
        Task<string> GetAllMovieGenres();

        /// <summary>
        /// Obtiene la lista de generos de las series
        /// </summary>
        /// <returns>Lista de generos en formato JSON</returns>
        Task<string> GetAllSeriesGenres();
    }
}
