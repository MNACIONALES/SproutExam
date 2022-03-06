using Sprout.Exam.Common.Enums;

namespace Sprout.Exam.Business.Contracts.Response
{
    public class SalaryComputationResponse
    {
        public int Id { get; set; }
        public string Computation { get; set; }
        public int EmployeeTypeId { get; set; }
        public string Rate { get; set; }
    }
}
