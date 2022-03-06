using AutoMapper;
using Moq;
using NUnit.Framework;
using Sprout.Exam.Business.Contracts.Request;
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
    public class EmployeeServiceTest
    {
        private readonly EmployeeService _employeeService;
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly Mock<ISalaryComputationRepository> _mockSalaryComputationRepository;
        private readonly Mock<IMapper> _mockMapper;

        public EmployeeServiceTest()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mockSalaryComputationRepository = new Mock<ISalaryComputationRepository>();
            _mockMapper = new Mock<IMapper>();
            _employeeService = new EmployeeService(_mockEmployeeRepository.Object, _mockMapper.Object, _mockSalaryComputationRepository.Object);
        }

        #region -- GetAll --
        [Test]
        public async Task GetAll_HasRecords_Success()
        {
            //ARRANGE
            var data = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FullName = "John Lennon",
                    Birthdate = new DateTime(1991,01,01),
                    Tin = "123321",
                    EmployeeTypeId = 1,
                    IsDeleted = false,
                    Salary = Convert.ToDecimal(20000)
                },
                 new Employee
                {
                    Id = 2,
                    FullName = "Paul McCartney",
                    Birthdate = new DateTime(1991,01,01),
                    Tin = "123321",
                    EmployeeTypeId = 2,
                    IsDeleted = false,
                    Salary = Convert.ToDecimal(500)
                }
            }.AsQueryable();
            _mockEmployeeRepository.Setup(t => t.GetAll(It.IsAny<Expression<Func<Employee, bool>>>())).Returns(data);


            var dataResponse = new List<EmployeeResponse>
            {
                new EmployeeResponse
                {
                    Id = 1,
                    FullName = "John Lennon",
                    Birthdate = new DateTime(1991,01,01).ToString("yyyy-MM-dd"),
                    Tin = "123321",
                    EmployeeTypeId = 1,
                    IsDeleted = false,
                    Salary = Convert.ToDecimal(20000)
                },
                 new EmployeeResponse
                {
                    Id = 2,
                    FullName = "Paul McCartney",
                    Birthdate = new DateTime(1991,01,01).ToString("yyyy-MM-dd"),
                    Tin = "123321",
                    EmployeeTypeId = 2,
                    IsDeleted = false,
                    Salary = Convert.ToDecimal(500)
                }
            };
            _mockMapper.Setup(t => t.Map<List<EmployeeResponse>>(It.IsAny<IQueryable<Employee>>())).Returns(dataResponse);

            //ACT
            var response = await _employeeService.GetAll();

            //ASSERT
            Assert.IsInstanceOf<List<EmployeeResponse>>(response);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any());
        }
        #endregion

        #region -- GetById --
        [Test]
        public async Task GetById_HasRecord_Success()
        {
            //ARRANGE

            var data = new Employee
            {
                Id = 1,
                FullName = "John Lennon",
                Birthdate = new DateTime(1991, 01, 01),
                Tin = "123321",
                EmployeeTypeId = 1,
                IsDeleted = false,
                Salary = Convert.ToDecimal(20000)
            };

            _mockEmployeeRepository.Setup(t => t.Get(It.IsAny<Expression<Func<Employee, bool>>>())).ReturnsAsync(data);


            var dataResponse = new EmployeeResponse
            {
                Id = 1,
                FullName = "John Lennon",
                Birthdate = new DateTime(1991, 01, 01).ToString("yyyy-MM-dd"),
                Tin = "123321",
                EmployeeTypeId = 1,
                IsDeleted = false,
                Salary = Convert.ToDecimal(20000)
            };
            _mockMapper.Setup(t => t.Map<EmployeeResponse>(It.IsAny<Employee>())).Returns(dataResponse);

            //ACT
            var response = await _employeeService.GetById(It.IsAny<int>());

            //ASSERT
            Assert.IsInstanceOf<EmployeeResponse>(response);
            Assert.IsNotNull(response);
        }
        #endregion

        #region -- Insert_Success --
        [Test]
        public async Task Insert_Success()
        {
            //ARRANGE
            var data = new Employee
            {
                Id = 3,
                FullName = "George Harrison",
                Birthdate = new DateTime(1991, 01, 01),
                Tin = "123321",
                EmployeeTypeId = 1,
                IsDeleted = false,
                Salary = Convert.ToDecimal(120000)
            };
            _mockMapper.Setup(t => t.Map<Employee>(It.IsAny<EmployeeRequest>())).Returns(data);

            _mockEmployeeRepository.Setup(t => t.Insert(It.IsAny<Employee>())).ReturnsAsync(data);


            var dataResponse = new EmployeeResponse
            {
                Id = 3,
                FullName = "George Harrison",
                Birthdate = new DateTime(1991, 01, 01).ToString("yyyy-MM-dd"),
                Tin = "123321",
                EmployeeTypeId = 1,
                IsDeleted = false,
                Salary = Convert.ToDecimal(120000)
            };
            _mockMapper.Setup(t => t.Map<EmployeeResponse>(It.IsAny<Employee>())).Returns(dataResponse);

            //ACT
            var response = await _employeeService.Insert(It.IsAny<EmployeeRequest>());

            //ASSERT
            Assert.IsInstanceOf<EmployeeResponse>(response);
            Assert.IsNotNull(response);
        }
        #endregion

        #region -- Update_Success --
        [Test]
        public async Task Update_Success()
        {
            //ARRANGE
            var data = new Employee
            {
                Id = 3,
                FullName = "George Harrison II",
                Birthdate = new DateTime(1991, 01, 01),
                Tin = "123321",
                EmployeeTypeId = 1,
                IsDeleted = false,
                Salary = Convert.ToDecimal(120000)
            };
            _mockMapper.Setup(t => t.Map<Employee>(It.IsAny<EmployeeRequest>())).Returns(data);

            _mockEmployeeRepository.Setup(t => t.Insert(It.IsAny<Employee>())).ReturnsAsync(data);


            var dataResponse = new EmployeeResponse
            {
                Id = 3,
                FullName = "George Harrison  II",
                Birthdate = new DateTime(1991, 01, 01).ToString("yyyy-MM-dd"),
                Tin = "123321",
                EmployeeTypeId = 1,
                IsDeleted = false,
                Salary = Convert.ToDecimal(120000)
            };
            _mockMapper.Setup(t => t.Map<EmployeeResponse>(It.IsAny<Employee>())).Returns(dataResponse);

            //ACT
            var response = await _employeeService.Update(It.IsAny<EmployeeRequest>());

            //ASSERT
            Assert.IsInstanceOf<EmployeeResponse>(response);
            Assert.IsNotNull(response);
            Assert.IsTrue(response != null);
        }
        #endregion

        #region -- Delete_Success --
        [Test]
        public async Task Delete_Success()
        {
            //ARRANGE
            var data = new Employee
            {
                Id = 3,
                FullName = "George Harrison II",
                Birthdate = new DateTime(1991, 01, 01),
                Tin = "123321",
                EmployeeTypeId = 1,
                IsDeleted = false,
                Salary = Convert.ToDecimal(120000)
            };

            _mockEmployeeRepository.Setup(t => t.Get(It.IsAny<Expression<Func<Employee, bool>>>())).ReturnsAsync(data);


            _mockEmployeeRepository.Setup(t => t.Update(It.IsAny<Employee>())).ReturnsAsync(data);

            var dataResponse = new EmployeeResponse
            {
                Id = 3,
                FullName = "George Harrison  II",
                Birthdate = new DateTime(1991, 01, 01).ToString("yyyy-MM-dd"),
                Tin = "123321",
                EmployeeTypeId = 1,
                IsDeleted = false,
                Salary = Convert.ToDecimal(120000)
            };
            _mockMapper.Setup(t => t.Map<EmployeeResponse>(It.IsAny<Employee>())).Returns(dataResponse);

            //ACT
            var response = await _employeeService.Delete(It.IsAny<int>());

            //ASSERT
            Assert.IsInstanceOf<EmployeeResponse>(response);
            Assert.IsNotNull(response);
            Assert.IsTrue(response != null);
        }
        #endregion

        #region -- CalculateSalary_Success --
        [Test]
        public async Task CalculateSalary_Success()
        {
            //ARRANGE
            var data = new Employee
            {
                Id = 3,
                FullName = "George Harrison II",
                Birthdate = new DateTime(1991, 01, 01),
                Tin = "123321",
                EmployeeTypeId = 1,
                IsDeleted = false,
                Salary = Convert.ToDecimal(120000)
            };

            _mockEmployeeRepository.Setup(t => t.Get(It.IsAny<Expression<Func<Employee, bool>>>())).ReturnsAsync(data);

            var salaryComputation = new SalaryComputation
            {
                Id = 1,
                EmployeeTypeId = 1,
                Computation = "salary - ( (salary / 22) * numberOfAbsents ) - (salary * 0.12)",
                Rate = Rate.Monthly
            };
            _mockSalaryComputationRepository.Setup(t => t.Get(It.IsAny<Expression<Func<SalaryComputation, bool>>>())).ReturnsAsync(salaryComputation);

            var salaryRequest = new CalculateSalaryRequest
            {
                Id = 0,
                AbsentDays = 3,
                WorkedDays = 0
            };

            //ACT
            var totalAmount = await _employeeService.CalculateSalary(It.IsAny<int>(), salaryRequest);

            //ASSERT
            Assert.IsInstanceOf<decimal>(totalAmount);
            Assert.IsNotNull(totalAmount);
            Assert.IsTrue(totalAmount > 0);
        }
        #endregion
    }
}
