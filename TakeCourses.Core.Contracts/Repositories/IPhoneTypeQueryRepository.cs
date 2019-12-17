using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.PhoneTypeDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IPhoneTypeQueryRepository
    {
        PhoneType GetPhoneTypeById(byte id);
        PhoneType GetPhoneTypeByName(string levelname);
        List<PhoneType> SearchPhoneType(PhoneTypeSearchDto phoneType);
    }
}
