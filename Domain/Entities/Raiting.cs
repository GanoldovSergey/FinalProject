namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Rating
    {
        public int Id { get; set; }
        public Nullable<int> Raiting { get; set; }
        public Nullable<int> User { get; set; }
        public Nullable<int> File { get; set; }

        public virtual File Files { get; set; }
        public virtual User Users { get; set; }
    }
}
