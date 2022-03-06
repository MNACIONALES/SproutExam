using System;
using System.Collections.Generic;

#nullable disable

namespace Sprout.Exam.DataAccess.Entities
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            SalaryComputations = new HashSet<SalaryComputation>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<SalaryComputation> SalaryComputations { get; set; }
    }
}
