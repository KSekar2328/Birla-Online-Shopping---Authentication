using CoreAuthentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreAuthentication.Data
{
    public class BirlaContext : IdentityDbContext
    {
        public BirlaContext(DbContextOptions<BirlaContext> options) : base(options)
        {

        }
        public DbSet<Product> Products
        {
            get;
            set;
        }
    }
}
