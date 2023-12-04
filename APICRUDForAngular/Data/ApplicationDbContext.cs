using APICRUDForAngular.Models;
using Microsoft.EntityFrameworkCore;

namespace APICRUDForAngular.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op):base(op)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
