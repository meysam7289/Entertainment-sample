using System;
using System.Collections.Generic;

namespace NosazEntertainment.Model
{
    public partial class SessionUsers
    {
        public Guid Id { get; set; }
        public Guid FkSession { get; set; }
        public Guid FkUser { get; set; }
        public bool IsWinner { get; set; }
        public bool IsRefuse { get; set; }
        public DateTimeOffset? RefuseTime { get; set; }

        public virtual Session FkSessionNavigation { get; set; }
        public virtual User FkUserNavigation { get; set; }
    }
}
