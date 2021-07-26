using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Common.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services 
{
    public class ScoreService : IScoreService
    {

        private readonly IScoreRepository _repository;
        private readonly IUserRepository _userRepository;

        public ScoreService(IScoreRepository repository, IUserRepository authRepository)
        {
            _repository = repository;
            _userRepository = authRepository;

        }


        public async Task<bool> setScore(Score score)
        {
            if(score.Value < 1 | score.Value > 5){
                throw new HandlerException(
               HttpStatusCode.NotFound,
               new List<string>() {
                        "Por favor ingrese una calificación con rango del 1 al 5"
               }
            );
            }
            if (!await _userRepository.UserIdExists(score.UserId))
            {
                throw new HandlerException(
              HttpStatusCode.NotFound,
              new List<string>() {
                        "Usuario invalido"
              }
              );
            }
            return await _repository.setScore(score);
        }
    }
}
