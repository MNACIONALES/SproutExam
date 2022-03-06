using System;

namespace Sprout.Exam.Business.Contracts.Response
{
   public class EmployeeResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Birthdate { get; set; }
        public string Tin { get; set; }
        public int EmployeeTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Salary { get; set; }
    }
}
