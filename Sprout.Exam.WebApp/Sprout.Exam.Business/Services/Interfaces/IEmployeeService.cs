using Sprout.Exam.Business.Contracts.Request;
using Sprout.Exam.Business.Contracts.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponse>> GetAll(bool isDeleted = false);
        Task<EmployeeResponse> GetById(int id);
        Task<EmployeeResponse> Insert(EmployeeRequest employeeRequest);
        Task<EmployeeResponse> Update(EmployeeRequest employeeRequest);
        Task<EmployeeResponse> Delete(int id);
        Task<decimal> CalculateSalary(int id, CalculateSalaryRequest calculateSalaryRequest);
    }
}
