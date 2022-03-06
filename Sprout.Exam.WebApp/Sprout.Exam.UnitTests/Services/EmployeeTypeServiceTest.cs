using AutoMapper;
using Moq;
using NUnit.Framework;
using Sprout.Exam.Business.Contracts.Response;
using Sprout.Exam.Business.Services;
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
    public class EmployeeTypeServiceTest
    {
        private readonly EmployeeTypeService _employeeTypeService;
        private readonly Mock<IEmployeeTypeRepository> _mockEmployeeTypeRepository;
        private readonly Mock<IMapper> _mockMapper;
        public EmployeeTypeServiceTest()
        {
            _mockEmployeeTypeRepository = new Mock<IEmployeeTypeRepository>();
            _mockMapper = new Mock<IMapper>();
            _employeeTypeService = new EmployeeTypeService(_mockEmployeeTypeRepository.Object, _mockMapper.Object);
        }

        #region -- GetAll --
        [Test]
        public async Task GetAll_HasRecords_Success()
        {
            //ARRANGE
            var data = new List<EmployeeType>
            {
                new EmployeeType
                {
                    Id = 1,
                  TypeName = "Regular"
                },
                 new EmployeeType
                {
                    Id = 2,
                  TypeName = "Contractual"
                }
            }.AsQueryable();
            _mockEmployeeTypeRepository.Setup(t => t.GetAll(It.IsAny<Expression<Func<EmployeeType, bool>>>())).Returns(data);


            var dataResponse = new List<EmployeeTypeResponse>
            {
                new EmployeeTypeResponse
                {
                    Id = 1,
                  TypeName = "Regular"

                },
                 new EmployeeTypeResponse
                {
                    Id = 2,
                  TypeName = "Contractual"
                }
            };
            _mockMapper.Setup(t => t.Map<List<EmployeeTypeResponse>>(It.IsAny<IQueryable<EmployeeType>>())).Returns(dataResponse);

            //ACT
            var response = await _employeeTypeService.GetAll();

            //ASSERT
            Assert.IsInstanceOf<List<EmployeeTypeResponse>>(response);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any());
        }
        #endregion

        #region -- GetById --
        [Test]
        public async Task GetById_HasRecord_Success()
        {
            //ARRANGE

            var data = new EmployeeType
            {
                Id = 2,
                TypeName = "Contractual"
            };

            _mockEmployeeTypeRepository.Setup(t => t.Get(It.IsAny<Expression<Func<EmployeeType, bool>>>())).ReturnsAsync(data);


            var dataResponse = new EmployeeTypeResponse
            {
                Id = 2,
                TypeName = "Contractual"
            };
            _mockMapper.Setup(t => t.Map<EmployeeTypeResponse>(It.IsAny<EmployeeType>())).Returns(dataResponse);

            //ACT
            var response = await _employeeTypeService.GetById(It.IsAny<int>());

            //ASSERT
            Assert.IsInstanceOf<EmployeeTypeResponse>(response);
            Assert.IsNotNull(response);
        }
        #endregion
    }
}
