using System;
using System.Collections.Generic;

namespace NosazEntertainment.Model
{
    public partial class Session
    {
        public Session()
        {
            SessionCategories = new HashSet<SessionCategories>();
            SessionRounds = new HashSet<SessionRounds>();
            SessionUsers = new HashSet<SessionUsers>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public DateTimeOffset? EndingTime { get; set; }
        public Guid? FkcancelUser { get; set; }
        public string CancelReason { get; set; }
        public int StatusType { get; set; }

        public virtual User FkcancelUserNavigation { get; set; }
        public virtual ICollection<SessionCategories> SessionCategories { get; set; }
        public virtual ICollection<SessionRounds> SessionRounds { get; set; }
        public virtual ICollection<SessionUsers> SessionUsers { get; set; }
    }
}
