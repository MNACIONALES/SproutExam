using AutoMapper;
using Sprout.Exam.Business.Contracts.Response;
using Sprout.Exam.Business.Services.Interfaces;
using Sprout.Exam.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services
{
    public class SalaryComputationService : ISalaryComputationService
    {
        private readonly ISalaryComputationRepository _salaryComputationRepository;
        private readonly IMapper _mapper;
        public SalaryComputationService(ISalaryComputationRepository salaryComputationRepository, IMapper mapper)
        {
            _salaryComputationRepository = salaryComputationRepository;
            _mapper = mapper;
        }
        public async Task<SalaryComputationResponse> GetByEmployeeType(int employeeTypeId)
        {
            var data = await _salaryComputationRepository.Get(t => t.EmployeeTypeId == employeeTypeId);
            var response = _mapper.Map<SalaryComputationResponse>(data);
            return response;
        }
    }
}
