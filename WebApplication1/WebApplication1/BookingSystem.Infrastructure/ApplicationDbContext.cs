using BookingSystem.BookingSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.BookingSystem.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Waitlist> Waitlists { get; set; }
    }
}
