using System;
using System.Collections.Generic;

namespace NosazEntertainment.Model
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
