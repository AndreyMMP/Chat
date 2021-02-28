using Chat.Business.Interfaces;
using Chat.Business.Models;
using Chat.Business.Services;
using Chat.Test.Fixtures;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Chat.Test
{
    [Collection(nameof(ActiveUserCollection))]
    public class ActiveUserServiceTest
    {
        readonly ActiveUserTestsFixture _activeUserTestsFixture;

        public ActiveUserServiceTest(ActiveUserTestsFixture activeUserTestsFixture)
        {
            _activeUserTestsFixture = activeUserTestsFixture;
        }

        [Fact(DisplayName = "Inclus�o de Usu�rio")]
        [Trait("Service.Adicionar", "Valida��o Inclus�o")]
        public void Adicionar_DevePersistirUsuario()
        {
            //Arrange
            var activeUserRepository = new Mock<IActiveUserRepository>();            
            var activeUserService = new ActiveUserService(activeUserRepository.Object);
            var user = _activeUserTestsFixture.GerarUsuario();

            //Act
            activeUserService.Adicionar(user, user.Nickname);

            //Assert
            activeUserRepository.Verify(s => s.Adicionar(user, user.Nickname), Times.Once);
        }
        [Fact(DisplayName = "Remo��o de Usu�rio")]
        [Trait("Service.ExcluirRegistro", "Valida��o Inclus�o")]
        public void Remover_DeveRemoverUsuario()
        {
            //Arrange
            var activeUserRepository = new Mock<IActiveUserRepository>();
            var activeUserService = new ActiveUserService(activeUserRepository.Object);
            var user = _activeUserTestsFixture.GerarUsuario();

            //Act
            activeUserService.ExcluirRegistro(user.Nickname);

            //Assert
            activeUserRepository.Verify(s => s.ExcluirRegistro(user.Nickname), Times.Once);
        }
        [Fact(DisplayName = "Obter Todos Usu�rios Ativos")]
        [Trait("Service.ObterTodos", "Valida��o Obter Todos")]
        public void ObterTodos_DeveRetornarTodosUsuarios()
        {
            //Arrange
            var activeUserRepository = new Mock<IActiveUserRepository>();
            var activeUserService = new ActiveUserService(activeUserRepository.Object);
            var users = new List<ActiveUser> { _activeUserTestsFixture.GerarUsuario() };
            activeUserRepository.Setup(s => s.ObterTodos()).Returns(users);

            //Act
            var result = activeUserService.ObterTodos();

            //Assert
            Assert.Equal(users, result);
        }
        [Fact(DisplayName = "Obter Usu�rio por ID")]
        [Trait("Service.ObterPorId", "Valida��o Obter Usu�rio por ID")]
        public void ObterPorID_DeveRetornarUsuario()
        {
            //Arrange
            var activeUserRepository = new Mock<IActiveUserRepository>();
            var activeUserService = new ActiveUserService(activeUserRepository.Object);
            var nickname = "TheBestUser1993";
            var user = _activeUserTestsFixture.GerarUsuario(nickname);
            activeUserRepository.Setup(s => s.ObterPorId(nickname)).Returns(user);

            //Act
            var result = activeUserService.ObterPorId(nickname);

            //Assert
            Assert.Equal(user, result);
        }
    }
}
