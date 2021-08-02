using Application.Common.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.UnitTests.InsertFilm.Mocks;
using Tests.UnitTests.Login.Mocks;
using Tests.UnitTests.PublicationCommunity.Mocks;
using Tests.UnitTests.RegistrarComentario.Mocks;
using Xunit;

namespace Tests.UnitTests.PublicationCommunity
{
    public class PublicationCommunityShould
    {
      
        private readonly PublicationCommunityRepositoryMock publicationRepository;
        private readonly IPublicationService publicationService;
        private readonly UserRepositoryMock _userRepository;

        public PublicationCommunityShould()
        {
            publicationRepository = new PublicationCommunityRepositoryMock();
            _userRepository = new UserRepositoryMock();
            publicationService = new PublicationService(publicationRepository.Object, _userRepository.Object);
        }
        
        [Fact]
        public async void PublicationContentIsEmpty()
        {
            // Arrange
            bool PublicationResponse;
            Publication publication = new Domain.Entities.Publication()
            {
                Title = "publicacion de lupin",
                Content = "",
                UserId = "0a92d309-7651-46df-bd7e-f9a9a51fe3be",
                
            };

            // Act
            PublicationResponse = await publicationService.SetPublication(publication);

            //Assert
            Assert.False(PublicationResponse);
        }
        

        [Fact]
        public async void PublicationContentIsNotEmpty()
        {
            // Arrange
            bool PublicationResponse;
            Publication publication = new Domain.Entities.Publication()
            {
                Title = "publicacion lupin",
                Content = "Es un mago del robo de identidad",
                UserId = "0a92d309-7651-46df-bd7e-f9a9a51fe3be",

            };
            Console.WriteLine(publication);
            // Act
            PublicationResponse = await publicationService.SetPublication(publication);
            //Assert
            Assert.True(PublicationResponse);
        }

        [Fact]
        public async void PublicationUserNotExists()
        {
            // Arrange
            bool PublicationResponse;
            Publication publication = new Domain.Entities.Publication()
            {
                Title = "publicacion lupin",
                Content = "Es un mago del robo de identidad",
                UserId = "",

            };
            Console.WriteLine(publication);
            // Act
            PublicationResponse = await publicationService.SetPublication(publication);
            //Assert
            Assert.False(PublicationResponse);
        }




    }
}
