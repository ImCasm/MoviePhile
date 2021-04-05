using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class MoviePhileDbContext : IdentityDbContext<User>
    {
        public MoviePhileDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
