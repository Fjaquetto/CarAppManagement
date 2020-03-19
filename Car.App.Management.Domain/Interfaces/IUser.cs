using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Car.App.Management.Domain.Interfaces
{
    public interface IUser
    {
        Guid GetUserId();
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
