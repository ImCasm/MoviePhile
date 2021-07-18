using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.Services;
using Application.Dto;
using Application.Services;
using Domain.Entities;
using Tests.UnitTests.InsertCommunity.Mocks;
using Tests.UnitTests.Login.Mocks;
using Xunit;

namespace Tests.UnitTests.AddUserToCommunity
{
    public class AddUserShould
    {
        private readonly CommunityRepositoryMock communityRepository;
        private readonly ICommunityService communityService;
        private readonly UserRepositoryMock _userRepository;

        public AddUserShould()
        {
            _userRepository = new UserRepositoryMock();
            communityRepository = new CommunityRepositoryMock();
            communityService = new CommunityService(communityRepository.Object, _userRepository.Object);
        }

        [Fact]
        public async void AddNewUser()
        {
            // Arrange
            CommunityUserDto communityUser = new CommunityUserDto { CommunityId = 2, UserId = "2" };

            // Act
            bool result = await communityService.SetRegisterUser(communityUser);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async void AddExistingUser()
        {
            // Arrange
            CommunityUserDto communityUser = new CommunityUserDto { CommunityId = 2, UserId = "1" };

            // Act
            bool result = await communityService.SetRegisterUser(communityUser);

            //Assert
            Assert.False(result);
        }
    }
}
