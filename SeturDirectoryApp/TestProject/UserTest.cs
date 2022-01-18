using Moq;
using SeturDirectoryApp.Controllers;
using SeturDirectoryApp.Models;
using System;
using Xunit;
using SeturDirectoryApp.Services.Users;
namespace TestProject
{
    public class UserTest
    {
        public Mock<IUserService> mock = new Mock<IUserService>();
        [Fact]
        public async void GetUserById()
        {
            mock.Setup(p => p.GetUserById(1)).ReturnsAsync("JK");
            UsersController emp = new UsersController(mock.Object);
            string result = await emp.GetUserById(1);
            Assert.Equal("JK", result);
        }

        [Fact]
        public async void GetUser()
        {
            var userDTO = new User()
            {
                Uuid = 3,
                Name = "Hilal",
                LastName = "yýldýrým",
                CantactInformationId = 1,
                Company = "türk telekom"
            };
            mock.Setup(p => p.GetUser(1)).ReturnsAsync(userDTO);
            UsersController emp = new UsersController(mock.Object);
            var result = await emp.GetUser(1);
            Assert.True(userDTO.Equals(result));
        }

        [Fact]
        public async void GetUserDetails()
        {
            var employeeDTO = new User()
            {
                Uuid = 1,
                Name = "Hilal",
                LastName = "Yýldýrým",
                CantactInformationId=2,
                Company="vodafone"

            };
            mock.Setup(p => p.GetUserDetails(1)).ReturnsAsync(employeeDTO);
            UsersController emp = new UsersController(mock.Object);
            var result = await emp.GetUserDetails(1);
            Assert.True(employeeDTO.Equals(result));
        }
    }
}
