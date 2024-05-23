using APIGateway.Application.Queries;
using APIGateway.Controllers;
using APIGateway.Domain.Entities;
using Bupa.Services.Tests.Mock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bupa.Services.Tests
{
    public class MOTCheckControllerTests
    {
        private readonly ManualMockMediator _mediatorMock;
        private readonly ManualMockLogger<MOTCheckController> _loggerMock;
        private readonly MOTCheckController _mOTCheckController;
        public MOTCheckControllerTests()
        {
            _mediatorMock = new ManualMockMediator();
            _loggerMock = new ManualMockLogger<MOTCheckController>();
            _mOTCheckController = new MOTCheckController(_loggerMock, _mediatorMock);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WhenQueryIsValid()
        {
            // Arrange
            var query = new GetMOTQuery { Registration = "bj60kvf" };

            var expectedResult = new VehicleResponse
            {
                Vehicle = new Vehicle { Model = "ALTEA" },
                ErrorMessage = ""
            }; 
            
            _mediatorMock.Response = new VehicleResponse
            {
                Vehicle = new Vehicle { Model = "ALTEA" },
                ErrorMessage = ""
            };
           
            // Act
            var result = await _mOTCheckController.Get(query);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<VehicleResponse>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(expectedResult, returnValue);
        }        
    }
}
