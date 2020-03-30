using System;
using System.Collections.Generic;

namespace NosazEntertainment.Model
{
    public partial class Category : BaseEntity
    {
        public Category()
        {
            SessionCategories = new HashSet<SessionCategories>();
        }

        public string Name { get; set; }

        public virtual ICollection<SessionCategories> SessionCategories { get; set; }
    }
}
