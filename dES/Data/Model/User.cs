using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace dES.Data.Model
{
    // Add profile data for application users by adding properties to the dESUser class
    public class User : IdentityUser
    {
        public virtual DateTime Birthday { get; set; }
        public virtual bool IsAdministrator { get; set; } = false;

        public virtual HashSet<Address> Address { get; set; }
    }
}
