using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Common.Exceptions;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdvertisingService : IAdvertisingService
    {
        private readonly IAdvertisingRepository _advertisingRepository;
        private readonly IMovieService _movieService;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentsService _paymentsService;

        public AdvertisingService(
            IAdvertisingRepository advertisingRepository,
            IMovieService movieService,
            IUserRepository userRepository,
            IPaymentsService paymentsService)
        {
            _advertisingRepository = advertisingRepository;
            _movieService = movieService;
            _userRepository = userRepository;
            _paymentsService = paymentsService;
        }

        public async Task<int> CreateAdvertising(Advertising advertising)
        {

            if (!await _movieService.ExistMovieOnDb(advertising.FilmId))
            {
                throw new HandlerException(
                    HttpStatusCode.NotFound,
                    new List<string>() { "No existe la pelicula con el id dado en MoviePhile." }
                );
            }

            if (!await _userRepository.UserIdExists(advertising.UserId))
            {
                throw new HandlerException(
                    HttpStatusCode.NotFound,
                    new List<string>() { "No existe el usuario con el id dado." }
                );
            }

            int advertisingDays = (advertising.DateOut - advertising.DateIn).Days;
            float paymentAmount = advertisingDays * (int)Payments.AmountByDay;

            Payment payment = new Payment()
            {
                Date = DateTime.UtcNow,
                Amount = paymentAmount
            };

            int paymentId = await _paymentsService.CreatePayment(payment);
            
            if (await AdvertisingExist(advertising.Id))
            {
                throw new HandlerException(
                    HttpStatusCode.BadRequest,
                    new List<string>() { "Ya existe el anuncio con el Id." }
                );
            }

            advertising.PaymentId = paymentId;
            return await _advertisingRepository.CreateAdvertising(advertising);
        }

        public async Task<bool> AdvertisingExist(int id)
        {
            return await _advertisingRepository.GetAdvertisingById(id) != null;
        }
    }
}
