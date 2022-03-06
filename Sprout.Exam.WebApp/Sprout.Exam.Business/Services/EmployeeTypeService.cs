using AutoMapper;
using Sprout.Exam.Business.Contracts.Response;
using Sprout.Exam.Business.Services.Interfaces;
using Sprout.Exam.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;
        private readonly IMapper _mapper;
        public EmployeeTypeService(IEmployeeTypeRepository employeeTypeRepository, IMapper mapper)
        {
            _employeeTypeRepository = employeeTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<EmployeeTypeResponse>> GetAll()
        {
            var data = await Task.FromResult(_employeeTypeRepository.GetAll());
            return _mapper.Map<List<EmployeeTypeResponse>>(data);
        }

        public async Task<EmployeeTypeResponse> GetById(int id)
        {
            var data = await _employeeTypeRepository.Get(t => t.Id == id);
            return _mapper.Map<EmployeeTypeResponse>(data);
        }
    }
}
