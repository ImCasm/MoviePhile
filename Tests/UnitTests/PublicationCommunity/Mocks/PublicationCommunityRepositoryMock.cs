using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repository;
using Moq;
using Domain.Entities;

namespace Tests.UnitTests.PublicationCommunity.Mocks
{
    class PublicationCommunityRepositoryMock : Mock<IPublicationRepository>
    {
        public PublicationCommunityRepositoryMock()
        {
            SetupMethods();
        }

        public void SetupSetPublication()
        {

          
            Setup(x => x.SetPublication(It.Is<Publication>(publicationCommunity => string.IsNullOrEmpty(publicationCommunity.Content))))
                .Returns(Task.FromResult(false));
            
            
            Setup(x => x.SetPublication(It.Is<Publication>(publicationCommunity => !string.IsNullOrEmpty(publicationCommunity.Content))))
                .Returns(Task.FromResult(true));
            
            Setup(x => x.SetPublication(It.Is<Publication>(publicationCommunity => string.IsNullOrEmpty(publicationCommunity.UserId))))
               .Returns(Task.FromResult(false));
            
        }

        private void SetupMethods()
        {
            SetupSetPublication();
        }
    }
}
