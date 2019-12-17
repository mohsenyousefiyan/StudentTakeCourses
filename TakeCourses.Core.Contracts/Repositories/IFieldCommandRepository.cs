using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IFieldCommandRepository
    {
        Field AddField(string fieldcode,string fieldname);
        Field EditField(Int16 id,string fieldcode, string fieldname);
        bool DeleteField(Int16 id);
    }
}
