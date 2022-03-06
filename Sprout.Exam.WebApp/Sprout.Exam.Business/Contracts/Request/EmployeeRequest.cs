using System;

namespace Sprout.Exam.Business.Contracts.Request
{
    public class EmployeeRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Tin { get; set; }
        public DateTime Birthdate { get; set; }
        public int EmployeeTypeId { get; set; }
        public decimal Salary { get; set; }
    }
}
