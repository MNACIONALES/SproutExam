using AutoMapper;
using Sprout.Exam.Business.Contracts.Request;
using Sprout.Exam.Business.Contracts.Response;
using Sprout.Exam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Mapper
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, EmployeeResponse>()
                .ForMember(dst => dst.Birthdate, o => o.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));
            //CreateMap<List<Employee>, List<EmployeeResponse>>();
            CreateMap<EmployeeRequest, Employee>();
        }
    }
}
