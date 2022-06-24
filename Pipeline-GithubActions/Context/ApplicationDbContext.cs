using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pipeline_GithubActions.Entity;

namespace Pipeline_GithubActions.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}
