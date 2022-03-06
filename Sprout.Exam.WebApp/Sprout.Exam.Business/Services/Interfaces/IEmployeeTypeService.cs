using Sprout.Exam.Business.Contracts.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services.Interfaces
{
    public interface IEmployeeTypeService
    {
        Task<List<EmployeeTypeResponse>> GetAll();
        Task<EmployeeTypeResponse> GetById(int id);
    }
}
