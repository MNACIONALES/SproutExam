using Sprout.Exam.Business.Contracts.Response;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services.Interfaces
{
   public interface ISalaryComputationService
    {
        Task<SalaryComputationResponse> GetByEmployeeType(int employeeTypeId);
    }
}
