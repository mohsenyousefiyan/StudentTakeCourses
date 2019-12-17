using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IAddressTypeCommandRepository
    {
        AddressType AddAddressType(string addresstypename);
        AddressType EditAddressType(byte id, string addresstypename);
        bool DeleteAddressType(byte id);
    }
}
