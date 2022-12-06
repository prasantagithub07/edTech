using edTech.DomainModels.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;

namespace edTech.DAL
{
    public class AppDbContext: IdentityDbContext<User, Role, int>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTopic> CourseTopics { get; set; }
        public DbSet<CourseLesson> CourseLessons { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(@"Data Source=DESKTOP-JBNSU49\SQLEXPRESS;Initial Catalog=edTech2;Integrated Security=True");
            }
            base.OnConfiguring(optionBuilder);
        }

    }
}
