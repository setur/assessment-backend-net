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
            var userDTO = new CantactInformation()
            {
                CantactInformationId = 1,
                InformationType = "telefon",
                Information = "5415287878"
            };
            mock.Setup(p => p.GetCantactInformation(1)).ReturnsAsync(userDTO);
            CantactInformationsController emp = new CantactInformationsController(mock.Object);
            var result = await emp.GetCantactInformation(1);
            Assert.True(userDTO.Equals(result));
        }


    }
}
