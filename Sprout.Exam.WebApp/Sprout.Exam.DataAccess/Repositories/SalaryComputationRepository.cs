using Sprout.Exam.DataAccess.Entities;
using Sprout.Exam.DataAccess.Repositories.Interfaces;

namespace Sprout.Exam.DataAccess.Repositories
{
    public class SalaryComputationRepository : BaseRepository<SalaryComputation>, ISalaryComputationRepository
    {
        public SalaryComputationRepository(SproutExamDbContext context) : base(context)
        {

        }
    }
}
