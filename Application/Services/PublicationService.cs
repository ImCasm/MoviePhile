using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _repository;

        public PublicationService(IPublicationRepository repository)
        {
            _repository = repository;
         
        }

        /// <summary>
        /// Metodo encargado de ingresar una publicación por medio del llamado al repositorio
        /// </summary>
        /// <param name="publication"></param>
        /// <returns></returns>
        public async Task<bool> SetPublication(Publication publication)
        {
            return await _repository.SetPublication(publication);
        }
    }
}
