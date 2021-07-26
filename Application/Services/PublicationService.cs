using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Common.Exceptions;
using Domain.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _repository;
        private readonly IUserRepository _userRepository;

        public PublicationService(IPublicationRepository repository, IUserRepository authRepository)
        {
            _repository = repository;
            _userRepository = authRepository;

        }

        /// <summary>
        /// Metodo encargado de ingresar una publicación por medio del llamado al repositorio
        /// </summary>
        /// <param name="publication"></param>
        /// <returns></returns>
        public async Task<bool> SetPublication(Publication publication)
        {
            if (await _userRepository.UserIdExists(publication.UserId) )
            {
                return await _repository.SetPublication(publication);
            }

            throw new HandlerException(
                HttpStatusCode.NotFound,
                new List<string>() {
                        "Usuario no encontrado, por favor registrese"
                }
            );
      
        }
    }
}
