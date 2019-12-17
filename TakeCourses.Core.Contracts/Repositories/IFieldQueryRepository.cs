using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.FieldDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
   public interface IFieldQueryRepository
    {
        Field GetFieldById(Int16 id);
        Field GetFieldByName(string fieldname);
        Field GetFieldByCode(string fieldcode);
        List<Field> SearchField(FieldSearchDto fieldSearch);
    }
}
