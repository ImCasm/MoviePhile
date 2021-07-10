using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Moq;
using System.Threading.Tasks;

namespace Tests.UnitTests.InsertCommunity.Mocks
{
    public class CommunityRepositoryMock : Mock<ICommunityRepository>
    {
        public CommunityRepositoryMock()
        {
            SetupMethods();
        }

        public void SetupGetCommunityByname()
        {
            Setup(x => x.GetCommunityByname(It.Is<string>(name => name.Equals("Comunidad existente"))))
                .Returns(Task.FromResult(new Community() { Id = 1, Name = "Cualquier comunidad" }));

            Setup(x => x.GetCommunityByname(It.Is<string>(name => !name.Equals("Comunidad existente"))))
                .Returns(Task.FromResult<Community>(null));
        }

        public void SetupSetCommunity()
        {
            Setup(x => x.SetCommunity(It.IsAny<Community>()))
                .Returns(Task.FromResult(true));
        }

        private void SetupMethods()
        {
            SetupGetCommunityByname();
            SetupSetCommunity();
        }
    }
}
