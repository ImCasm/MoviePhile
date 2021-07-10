using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface ISerieService
    {
        /// <summary>
        /// Obtiene la lista de las serie más populares del momento
        /// </summary>
        /// <param name="page">Número de la página que se quiere obtener</param>
        /// <returns>Lista de series en formato JSON</returns>
        Task<string> GetPopularSeries(int page);

        /// <summary>
        /// Obtiene un JSON con una lista de series según su nombre
        /// </summary>
        /// <param name="query">Filtro del nombre de la serie</param>
        /// <param name="page">Página de la lista que se quiere obtener</param>
        /// <returns>La lista de series en formato JSON</returns>
        Task<string> GetSeriesByName(string query, int page);

        /// <summary>
        /// Obtiene una serie por su Id.
        /// Caso 1. Si existe en la base de datos, la retorna con sus relaciones,
        /// como por ejemplo los comentarios de esa serie
        /// Caso 2. Si no existe en la base de datos llama al cliente http para traerla desde el API externa,
        /// adicionalmente la convierte de objeto JSON a una entidad del negocio
        /// </summary>
        /// <param name="id">Id de la serie</param>
        /// <returns>La serie encontrada</returns>
        Task<TvShow> GetSerieById(int id);

        /// <summary>
        /// Permite guardar una serie por medio del repositorio de datos
        /// </summary>
        /// <param name="movie">Serie que se va a guardar</param>
        /// <returns>Serie guardada</returns>
        Task<TvShow> InsertSerie(TvShow serie);
    }
}
