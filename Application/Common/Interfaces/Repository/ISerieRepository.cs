using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface ISerieRepository : IRepository<TvShow>
    {
        /// <summary>
        /// Obtiene una serie por id desde la base de datos.
        /// Se utiliza en el caso de que la serie esté referenciada a otra entidad,
        /// como por ejemplo comentarios o publicidades.
        /// </summary>
        /// <param name="id">Id de la serie</param>
        /// <returns>La serie encontrada</returns>
        Task<TvShow> GetSerieById(int id);

        /// <summary>
        /// Permite guardar una serie en la base de datos.
        /// Eso sucede en el caso que existan relaciones de comentarios o publicidades de esa serie
        /// </summary>
        /// <param name="serie">Objeto de serie que se va a guardar</param>
        /// <returns>La serie guardada en la base de datos</returns>
        Task<TvShow> InsertSerie(TvShow serie);
    }
}
