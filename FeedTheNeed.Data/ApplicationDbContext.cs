using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedTheNeed.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Posting> PostingTable { get; set; }
        public DbSet<Organization> OrganizationTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Posting>()
                .HasRequired(p => p.User);
        }
    }
    ////Creating the primary key for our user
    //public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    //{
    //    public IdentityUserLoginConfiguration()
    //    {
    //        HasKey(iul => iul.UserID);
    //    }
    //}
    ////Creating primary key for user role
    //public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    //{

    //    public IdentityUserRoleConfiguration()
    //    {
    //        HasKey(iur => iur.UserID);
    //    }
    //}
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }
}
