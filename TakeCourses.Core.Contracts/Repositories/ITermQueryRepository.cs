using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.TermDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface ITermQueryRepository
    {
        Term GetTermById(int id);
        Term GetTermByTitle(string termtitle);
        List<Term> SearchTerm(TermSearchDto addressType);
    }
}
