using Application.Common.Interfaces.Repository;
using Domain.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly MoviePhileDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(MoviePhileDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = _table.AsQueryable<T>();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            var res = await query.ToListAsync();
            return res.AsQueryable();
        }

        public async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id);
        }

        public IEnumerable<T> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            return _table.Where(filter);
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return GetAllByFilter(filter).FirstOrDefault();
        }

        public async Task<T> Insert(T entity)
        {
            await _table.AddAsync(entity);

            if (await Save() > 0 )
            {
                return entity;
            }

            throw new HandlerException(
                HttpStatusCode.InternalServerError,
                new List<string>() {
                    "Ha ocurrido un error al intentar insertar los datos."
                }
            );
        }

        public async Task<T> Update(T modifiedEntity)
        {
            _context.Attach(modifiedEntity);
            _context.Entry(modifiedEntity).State = EntityState.Modified;

            if (await Save() > 0)
            {
                return modifiedEntity;
            }

            throw new HandlerException(
                HttpStatusCode.InternalServerError,
                new List<string>() {
                    "Ha ocurrido un error al intentar actualizar los datos."
                }
            );
        }

        public async Task<bool> Delete(object id)
        {
            string error = "No se encontró el registro.";
            HttpStatusCode code = HttpStatusCode.NotFound;

            T existingEntity = await GetById(id);

            if (existingEntity != null)
            {
                _table.Remove(existingEntity);

                if (await Save() > 0)
                {
                    return true;
                }

                error = "Ha ocurrido un error al intentar eliminar los datos";
                code = HttpStatusCode.InternalServerError;
            }

            throw new HandlerException(
                code,
                new List<string>() {
                    error
                }
            );
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
