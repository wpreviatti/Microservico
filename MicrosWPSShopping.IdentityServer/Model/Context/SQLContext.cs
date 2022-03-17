using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MicrosWPSShopping.IdentityServer.Model.Context
{
    public class SQLContext : IdentityDbContext
    {
        public SQLContext() { }
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

       
    }
}
