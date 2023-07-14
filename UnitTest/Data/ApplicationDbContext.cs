using Microsoft.EntityFrameworkCore;
using UnitTest.Model;

namespace UnitTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public virtual DbSet<ShoppingItem> ShoppingItems  { get; set; }
    }
}
