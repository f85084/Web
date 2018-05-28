using System.Data.Entity;
using Web.Models;

namespace Web.Data
{
    public class WebContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Reply> Replys { get; set; }
    }
}
