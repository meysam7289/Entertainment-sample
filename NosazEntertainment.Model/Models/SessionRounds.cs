using System;
using System.Collections.Generic;

namespace NosazEntertainment.Model
{
    public partial class SessionRounds
    {
        public Guid Id { get; set; }
        public Guid FkSession { get; set; }
        public int RoundNumber { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public DateTimeOffset? EndingTime { get; set; }
        public string RoundLetter { get; set; }

        public virtual Session FkSessionNavigation { get; set; }
    }
}
