using AutoMapper;
using Sprout.Exam.Business.Contracts.Response;
using Sprout.Exam.DataAccess.Entities;

namespace Sprout.Exam.Business.Mapper
{
    public class SalaryComputationMapper : Profile
    {
        public SalaryComputationMapper()
        {
            CreateMap<SalaryComputation, SalaryComputationResponse>()
                .ForMember(dst => dst.Rate, o => o.MapFrom(src => src.Rate.ToString()));
        }
    }
}
