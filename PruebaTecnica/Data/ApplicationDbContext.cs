using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options) { 
        
        }
    }
}
