namespace Domain.Concrete
{
    using System;
    using System.Data.Entity;
    using Domain.Entities;

    public partial class Context : DbContext
    {
        public Context()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
