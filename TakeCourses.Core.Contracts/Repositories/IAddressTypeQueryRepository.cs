using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.AddressType;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IAddressTypeQueryRepository
    {
        AddressType GetAddressTypeById(byte id);
        AddressType GetAddressTypeByName(string addresstypename);
        List<AddressType> SearchAddressType(AddressTypeSearchDto addressType);
    }
}
