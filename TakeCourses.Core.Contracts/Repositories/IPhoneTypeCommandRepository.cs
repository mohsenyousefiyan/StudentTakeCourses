using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IPhoneTypeCommandRepository
    {
        PhoneType AddPhoneType(string phonetypename);
        PhoneType EditPhoneType(byte id, string phonetypename);
        bool DeletePhoneType(byte id);
    }
}
