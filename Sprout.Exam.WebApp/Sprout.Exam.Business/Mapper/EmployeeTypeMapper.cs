using AutoMapper;
using Sprout.Exam.Business.Contracts.Request;
using Sprout.Exam.Business.Contracts.Response;
using Sprout.Exam.DataAccess.Entities;

namespace Sprout.Exam.Business.Mapper
{
    public class EmployeeTypeMapper : Profile
    {
        public EmployeeTypeMapper()
        {
            CreateMap<EmployeeType, EmployeeTypeResponse>();
            CreateMap<EmployeeTypeRequest, EmployeeType>();
        }
    }
}
