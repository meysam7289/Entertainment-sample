using System;
using System.Collections.Generic;

namespace NosazEntertainment.Model
{
    public partial class SessionCategories
    {
        public Guid Id { get; set; }
        public Guid FkSession { get; set; }
        public Guid FkCategory { get; set; }

        public virtual Category FkCategoryNavigation { get; set; }
        public virtual Session FkSessionNavigation { get; set; }
    }
}
