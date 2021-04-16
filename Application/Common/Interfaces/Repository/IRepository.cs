using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    /// <summary>
    /// Repositorio generico que se utilzará para gestionar las entidades en la base de datos
    /// </summary>
    /// <typeparam name="T">Genérico que será la clase base de la entidad</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obtiene la colección de datos de una entidad
        /// </summary>
        /// <returns>Colección de datos en la tabla de la entidad</returns>
        Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Obtiene una entidad por id
        /// </summary>
        /// <param name="id">Id de la entidad a obtener</param>
        /// <returns>El objeto entidad si existe, null si no existe</returns>
        Task<T> GetById(object id);

        /// <summary>
        /// Obtiene la colección de datos de una entidad, dado un filtro
        /// </summary>
        /// <param name="filter">Expresión lambda que funcionará como filtro para relaliza la búsqueda</param>
        /// <returns>Colección de datos en la tabla de la entidad que cumplen con el filtro</returns>
        IEnumerable<T> GetAllByFilter(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Obtiene una entidad, dado un filtro, si existe más de una entidad que cumple el filtro, se revuelve la primera
        /// </summary>
        /// <param name="filter">Expresión lambda que funcionará como filtro para relaliza la búsqueda</param>
        /// <returns>Colección de datos en la tabla de la entidad que cumplen con el filtro</returns>
        T GetByFilter(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Inserta una entidad en la base de datos
        /// </summary>
        /// <param name="entity">Objeto de la entidad que se va a insertar</param>
        /// <returns>El objeto de la entidad insertada en la base de datos</returns>
        Task<T> Insert(T entity);

        /// <summary>
        /// Actualiza una entidad por su id en la base de datos
        /// </summary>
        /// <param name="modifiedEntity">Objeto de la entidad a modificar</param>
        /// <returns>El objeto de la entidad modificada</returns>
        Task<T> Update(T modifiedEntity);

        /// <summary>
        /// Elimina una entidad de la base de datos por su id
        /// </summary>
        /// <param name="id">Id de la entidad a eliminar</param>
        /// <returns>True si lo eliminó de la base de datos, false de otra forma</returns>
        Task<bool> Delete(object id);

        /// <summary>
        /// Guarda los cambios realizados en la base de datos
        /// </summary>
        /// <returns>Cantidad de registros que se afectó</returns>
        Task<int> Save();
    }
}
