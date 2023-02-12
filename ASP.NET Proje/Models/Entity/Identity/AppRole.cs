using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Proje.Models.Identity
{
    public class AppRole : IdentityRole<int>
    {
        internal T Adapt<T>()
        {
            throw new NotImplementedException();
        }
    }
}
