using System;

namespace NosazEntertainment.Model
{
    public partial class UserRoles
    {
        public Guid FkUser { get; set; }
        public Guid FkRole { get; set; }

        public virtual Role FkRoleNavigation { get; set; }
        public virtual User FkUserNavigation { get; set; }
    }
}
