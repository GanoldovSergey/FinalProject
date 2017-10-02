namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class File
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public File()
        {
            this.Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Size { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? Rating { get; set; }
        public int? Number_Of_Raitings { get; set; }
        public byte[] Files { get; set; }
        public int? UserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual User Users { get; set; }
    }
}
