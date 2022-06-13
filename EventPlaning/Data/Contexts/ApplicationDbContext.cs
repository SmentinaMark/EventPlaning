using EventPlaning.Models;
using EventPlaning.Models.UserEvents;
using EventPlaning.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventPlaning.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<EventParticipant> EventPartisipiants { get; set; }
        public DbSet<User> User { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
