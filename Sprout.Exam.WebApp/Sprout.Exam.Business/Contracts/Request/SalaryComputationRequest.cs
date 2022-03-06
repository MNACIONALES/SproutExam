using Sprout.Exam.Common.Enums;

namespace Sprout.Exam.Business.Contracts.Request
{
    public class SalaryComputationRequest
    {
        public int Id { get; set; }
        public string Computation { get; set; }
        public int EmployeeTypeId { get; set; }
        public Rate Rate { get; set; }
    }
}
