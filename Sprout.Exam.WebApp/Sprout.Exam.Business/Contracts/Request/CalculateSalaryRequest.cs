
namespace Sprout.Exam.Business.Contracts.Request
{
    public class CalculateSalaryRequest
    {
        public int Id { get; set; }
        public decimal AbsentDays { get; set; }
        public decimal WorkedDays { get; set; }
    }
}
