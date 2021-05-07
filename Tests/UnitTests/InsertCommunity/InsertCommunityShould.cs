﻿using Application.Common.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Tests.UnitTests.InsertCommunity.Mocks;
using Xunit;

namespace Tests.UnitTests.InsertCommunity
{
    public class InsertCommunityShould
    {
        private readonly CommunityRepositoryMock communityRepository;
        private readonly ICommunityService communityService;

        public InsertCommunityShould()
        {
            communityRepository = new CommunityRepositoryMock();
            communityService = new CommunityService(communityRepository.Object);
        }

        [Fact]
        public async void InsertValidCommunity()
        {
            // Arrange
            Community community = new Community()
            {
                Name = "Comunidad de Harry Potter",
                Description = "Comunidad de la saga de fantasía basada en las novelas de JK Rowling"
            };

            // Act
            bool result = await communityService.SetCommunity(community);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async void InsertInvalidCommunity()
        {
            // Arrange
            Community community = new Community()
            {
                Name = "Comunidad existente",
                Description = "El nombre de esta comunidad ya existe"
            };

            // Act
            bool result = await communityService.SetCommunity(community);

            //Assert
            Assert.False(result);
        }
    }
}
