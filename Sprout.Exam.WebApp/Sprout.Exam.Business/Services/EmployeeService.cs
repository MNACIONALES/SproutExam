using AutoMapper;
using Sprout.Exam.Business.Contracts.Request;
using Sprout.Exam.Business.Contracts.Response;
using Sprout.Exam.Business.Services.Interfaces;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.DataAccess.Entities;
using Sprout.Exam.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISalaryComputationRepository _salaryComputationRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, ISalaryComputationRepository salaryComputationRepositor
            )
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _salaryComputationRepository = salaryComputationRepositor;
        }

        public async Task<List<EmployeeResponse>> GetAll(bool isDeleted = false)
        {
            var data = await Task.FromResult(_employeeRepository.GetAll(t => t.IsDeleted == isDeleted));
            var response = _mapper.Map<List<EmployeeResponse>>(data);
            return response;
        }

        public async Task<EmployeeResponse> GetById(int id)
        {
            var data = await _employeeRepository.Get(t => t.Id == id);
            if (data is null) return null;
            var response = _mapper.Map<EmployeeResponse>(data);
            return response;
        }

        public async Task<EmployeeResponse> Insert(EmployeeRequest employeeRequest)
        {
            var request = _mapper.Map<Employee>(employeeRequest);
            var data = await _employeeRepository.Insert(request);
            var response = _mapper.Map<EmployeeResponse>(data);
            return response;
        }

        public async Task<EmployeeResponse> Update(EmployeeRequest employeeRequest)
        {
            var request = _mapper.Map<Employee>(employeeRequest);
            var employee = await _employeeRepository.Get(t => t.Id == request.Id);
            if (employee is null) return null;

            var data = await _employeeRepository.Update(request);
            return _mapper.Map<EmployeeResponse>(data);

        }
        public async Task<EmployeeResponse> Delete(int id)
        {
            var data = await _employeeRepository.Get(t => t.Id == id);
            if (data is null) return null;

            data.IsDeleted = true;
            data = await _employeeRepository.Update(data);
            var response = _mapper.Map<EmployeeResponse>(data);
            return response;
        }

        public async Task<decimal> CalculateSalary(int id, CalculateSalaryRequest calculateSalaryRequest)
        {
            var data = await _employeeRepository.Get(t => t.Id == id);
            if (data is null) return 0;

            var salaryComputation = await _salaryComputationRepository.Get(t => t.EmployeeTypeId == data.EmployeeTypeId);
            var totalSalary = Convert.ToDecimal(0);

            if (calculateSalaryRequest.WorkedDays > 0 && salaryComputation.Rate == Rate.Daily)
            {
                var computation = salaryComputation.Computation;
                computation = computation.Replace("dailyRate", data.Salary.ToString());
                computation = computation.Replace("numberOfWorkDays", calculateSalaryRequest.WorkedDays.ToString());
                DataTable dt = new();
                totalSalary = Convert.ToDecimal(dt.Compute(computation, ""));
                return Math.Round(totalSalary, 2);
            }

            if (calculateSalaryRequest.AbsentDays > 0 && salaryComputation.Rate == Rate.Monthly)
            {
                var computation = salaryComputation.Computation;
                computation = computation.Replace("salary", data.Salary.ToString());
                computation = computation.Replace("numberOfAbsents ", calculateSalaryRequest.AbsentDays.ToString());
                DataTable dt = new();
                totalSalary = Convert.ToDecimal(dt.Compute(computation, ""));
                return Math.Round(totalSalary, 2);
            }

            return Math.Round(totalSalary, 2);
        }
    }
}
