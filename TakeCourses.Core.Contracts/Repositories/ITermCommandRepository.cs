using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.TermDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface ITermCommandRepository
    {
        Term AddTerm(TermAddDto termdto);
        Term EditTerm(int id, TermAddDto termdto);
        bool DeleteTerm(int id);
    }
}
