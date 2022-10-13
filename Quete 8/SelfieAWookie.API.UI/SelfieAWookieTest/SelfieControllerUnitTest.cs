using Microsoft.AspNetCore.Mvc;
using Moq;
using SelfieAWookie.API.UI.Application.DTOs;
using SelfieAWookie.API.UI.Controllers;
using SelfieAWookie.Core.Selfies.Domain;
using SelfiesAWookies.Core.Framework;

namespace SelfieAWookieTest
{
    public class SelfieControllerUnitTest
    {
       
        [Fact]
        public void ShouldAddOneSelfie()
        {
            SelfieDTO slf = new SelfieDTO();
            var repositoryMock = new Mock<ISelfieRepository>();
            var controller = new SelfieController(repositoryMock.Object);
            var unit = new Mock<IUnitOfWork>();
            repositoryMock.Setup(item => item.UnitOfWork).Returns(new Mock<IUnitOfWork>().Object);
            repositoryMock.Setup(item => item.AddOne(It.IsAny<Selfie>())).Returns(new Selfie() { Id = 4 });
            var result = controller.AddOne(slf);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var addedSelfie = (result as OkObjectResult).Value as SelfieDTO;
            Assert.NotNull(addedSelfie);
            Assert.True(addedSelfie.Id>0);
        }

        [Fact]
        public void ShouldReturnListOfSelfies()
        {

            //ARRANGE
            var expectedList = new List<Selfie>()
            {
                new Selfie() {Wookie = new Wookie()},
                new Selfie() {Wookie = new Wookie()}
            };


            var repositoryMock = new Mock<ISelfieRepository>();

            repositoryMock.Setup(item => item.GetAll(It.IsAny<int>())).Returns(expectedList);
            var controller = new SelfieController(repositoryMock.Object);


            //ACT

            var result = controller.Get();

            //ASSERT

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;
            Assert.IsType<List<SelfieResumeDTO>>(okResult.Value);
            Assert.NotNull(okResult.Value);

            List<SelfieResumeDTO> list = okResult.Value as List<SelfieResumeDTO>;
            Assert.True(list.Count == expectedList.Count);

        }
    }
}