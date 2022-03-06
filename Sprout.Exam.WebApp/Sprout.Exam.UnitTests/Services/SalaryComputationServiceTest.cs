using AutoMapper;
using Moq;
using NUnit.Framework;
using Sprout.Exam.Business.Contracts.Response;
using Sprout.Exam.Business.Services;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.DataAccess.Entities;
using Sprout.Exam.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.UnitTests.Services
{
    [TestFixture]
    public class SalaryComputationServiceTest
    {
        private readonly SalaryComputationService _salaryComputationService;
        private readonly Mock<ISalaryComputationRepository> _mockSalaryComputationRepository;
        private readonly Mock<IMapper> _mockMapper;
        public SalaryComputationServiceTest()
        {
            _mockSalaryComputationRepository = new Mock<ISalaryComputationRepository>();
            _mockMapper = new Mock<IMapper>();
            _salaryComputationService = new SalaryComputationService(_mockSalaryComputationRepository.Object, _mockMapper.Object);
        }

        #region GetByEmployeeType_HasRecord_Success
        [Test]
        public async Task GetByEmployeeType_HasRecord_Success()
        {
            //ARRANGE
            var salaryComputation = new SalaryComputation
            {
                Id = 1,
                EmployeeTypeId = 1,
                Computation = "salary - ( (salary / 22) * numberOfAbsents ) - (salary * 0.12)",
                Rate = Rate.Monthly
            };
            _mockSalaryComputationRepository.Setup(t => t.Get(It.IsAny<Expression<Func<SalaryComputation, bool>>>())).ReturnsAsync(salaryComputation);

            var dataResponse = new SalaryComputationResponse
            {
                Id = 1,
                EmployeeTypeId = 1,
                Computation = "salary - ( (salary / 22) * numberOfAbsents ) - (salary * 0.12)",
                Rate = Rate.Monthly.ToString()
            };
            _mockMapper.Setup(t => t.Map<SalaryComputationResponse>(It.IsAny<SalaryComputation>())).Returns(dataResponse);

            //ACT
            var response = await _salaryComputationService.GetByEmployeeType(It.IsAny<int>());

            //ASSERT
            Assert.IsInstanceOf<SalaryComputationResponse>(response);
            Assert.IsNotNull(response);

        }
        #endregion
    }
}
