using Application.Common.Interfaces.Auth;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Threading.Tasks;

namespace Tests.UnitTests.Login.Mocks
{
    public class UserRepositoryMock : Mock<IUserRepository>
    {
        public UserRepositoryMock()
        {
            SetupMethods();
        }

        public void SetupUserExists()
        {
            Setup(x => x.UserExists(It.Is<string>(email => email.Equals("noexiste@gmail.com"))))
               .Returns(Task.FromResult(false));

            Setup(x => x.UserExists(It.Is<string>(email => !email.Equals("noexiste@gmail.com"))))
               .Returns(Task.FromResult(true));
        }

        public void SetupFindByEmail()
        {
            Setup(x => x.FindByEmail(It.Is<string>(email => email.Equals("incorrecto@gmail.com"))))
               .Returns(Task.FromResult(new User { 
                    Email = "incorrecto@gmail.com",
                    UserName = "123"
               }));

            Setup(x => x.FindByEmail(It.Is<string>(email => !email.Equals("incorrecto@gmail.com"))))
               .Returns(Task.FromResult(new User
               {
                   Email = "usuario@gmail.com",
                   UserName = "123"
               }));
        }

        public void SetupCheckCredentials()
        {
            Setup(x => x.CheckCredentials(It.Is<User>(
                user => user.Email.Equals("incorrecto@gmail.com")), 
                It.IsAny<string>()))
              .Returns(Task.FromResult(false));

            Setup(x => x.CheckCredentials(It.Is<User>(user => !user.Email.Equals("incorrecto@gmail.com")), It.IsAny<string>()))
              .Returns(Task.FromResult(true));
        }

        public void SetupCreateUser()
        {
            Setup(x => x.CreateUser(It.IsAny<User>(),It.IsAny<string>()))
              .Returns(Task.FromResult(IdentityResult.Success));
        }

        private void SetupMethods()
        {
            SetupCheckCredentials();
            SetupFindByEmail();
            SetupUserExists();
            SetupUserIdExist();
            SetupCreateUser();
        }

        public void SetupUserIdExist()
        {
            Setup(x => x.UserIdExists(It.IsAny<string>()))
               .Returns(Task.FromResult(true));
        }
    }
}
