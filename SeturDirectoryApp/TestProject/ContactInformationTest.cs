using Microsoft.AspNetCore.Mvc;
using Moq;
using SeturDirectoryApp.Controllers;
using SeturDirectoryApp.Models;
using SeturDirectoryApp.Services.ContactInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    
    public class ContactInformationTest
    {
        public Mock<IContactInformationService> mock = new Mock<IContactInformationService>();

        [Fact]
        public async void GetCantactInformation()
        {
            var cI = new CantactInformation()
            {
                CantactInformationId = 1,
                InformationType = "telefon",
                Information = "5415287878"
            };
            mock.Setup(p => p.GetCantactInformation(1)).ReturnsAsync(cI);
            CantactInformationsController emp = new CantactInformationsController(mock.Object);
            var result = await emp.GetCantactInformation(1);
            Assert.True(cI.Equals(result));
        }

        [Fact]
        public async Task DeleteCantactInformation()
        {

            mock.Setup(repo => repo.GetCantactInformation(1)).ReturnsAsync(new CantactInformation() { });
            mock.Setup(repo => repo.DeleteCantactInformation(It.IsAny<int>())).Returns((Task<IActionResult>)Task.CompletedTask).Verifiable();

            // Act
            CantactInformationsController emp = new CantactInformationsController(mock.Object);
            var result = await emp.DeleteCantactInformation(1);

            // Assert
            mock.Verify(repo => repo.DeleteCantactInformation(It.IsAny<int>()), Times.Once);


            //int testId = 2;

            //mock.Setup(repo => repo.DeleteCantactInformation(It.IsAny<int>()))
            //       .Returns((Task<IActionResult>)Task.CompletedTask).Verifiable();

            //var controller = new CantactInformationsController(mock.Object);

            //// Act
            //var result = await controller.DeleteCantactInformation(testId);

            //// Assert
            //var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            //Assert.Null(redirectToActionResult.ControllerName);
            //Assert.Equal("Read", redirectToActionResult.ActionName);
            //mock.Verify();
        }





    }
}
