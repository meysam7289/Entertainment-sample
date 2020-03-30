using System;
using System.Collections.Generic;

namespace NosazEntertainment.Model
{
    public partial class User
    {
        public User()
        {
            Session = new HashSet<Session>();
            SessionUsers = new HashSet<SessionUsers>();
            UserRoles = new HashSet<UserRoles>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string PersonnelCode { get; set; }
        public int StatusType { get; set; }
        public string StatusMessage { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsActive { get; set; }
        public string SerialNumber { get; set; }

        public virtual ICollection<Session> Session { get; set; }
        public virtual ICollection<SessionUsers> SessionUsers { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
