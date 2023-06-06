using Back_End.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Context
{
    public class AplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ActivatedUser> ActivatedUsers { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext>options):base(options)
        {
           
        }
    }
}
