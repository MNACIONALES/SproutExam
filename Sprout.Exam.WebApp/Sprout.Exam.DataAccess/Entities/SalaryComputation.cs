using Sprout.Exam.Common.Enums;

#nullable disable

namespace Sprout.Exam.DataAccess.Entities
{
    public partial class SalaryComputation
    {
        public int Id { get; set; }
        public string Computation { get; set; }
        public int EmployeeTypeId { get; set; }
        public Rate Rate { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }
    }
}
