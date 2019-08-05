//Creating new DbContext by using User class  
using FeedTheNeed.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }
    public ApplicationDbContext()
        : base("FeedTheNeedContext", throwIfV1Schema: false)
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
    }
}
//Creating the primary key for our user
public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
{
    public IdentityUserLoginConfiguration()
    {
        HasKey(iul => iul.UserId);
    }
}
//Creating primary key for user role
public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
{

    public IdentityUserRoleConfiguration()
    {
        HasKey(iur => iur.UserId);
    }
}
public class ApplicationRole : IdentityRole
{
    public ApplicationRole() : base() { }
    public ApplicationRole(string roleName) : base(roleName) { }
}