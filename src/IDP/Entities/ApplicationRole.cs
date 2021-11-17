using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IDP.Entities
{
    // Extending IdentityRole
    public class ApplicationRole : IdentityRole<Guid>
    {
        //Im free to add props here
    }
}


