using edTech.DAL.Implementations;
using edTech.DAL.Interfaces;
using edTech.DAL;
using edTech.DomainModels.Entities;
using edTech.Services.Implementations;
using edTech.Services.Interfaces;
//using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace edTech.Services.Configuration
{
    public static class ConfigureDependencies
    {
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddIdentity<User, Role>().
                AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddScoped<DbContext, AppDbContext>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();

            services.AddTransient<IRepository<Course>, Repository<Course>>();
            services.AddTransient<IRepository<Mentor>, Repository<Mentor>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<CourseTopic>, Repository<CourseTopic>>();
            services.AddTransient<IRepository<CourseLesson>, Repository<CourseLesson>>();
            services.AddTransient<IRepository<Subscription>, Repository<Subscription>>();

            services.AddTransient<ITopicRepository, TopicRepository>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();

            services.AddTransient<IRepository<CartItem>, Repository<CartItem>>();
            services.AddTransient<IRepository<OrderItem>, Repository<OrderItem>>();
            services.AddTransient<IRepository<PaymentDetails>, Repository<PaymentDetails>>();

            //Services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IService<Course>, Service<Course>>();
            services.AddScoped<IService<CourseTopic>, Service<CourseTopic>>();
            services.AddScoped<IService<CourseLesson>, Service<CourseLesson>>();
            services.AddScoped<IService<Category>, Service<Category>>();
            services.AddScoped<IService<Subscription>, Service<Subscription>>();
            services.AddScoped<IService<Mentor>, Service<Mentor>>();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
        }
    }
}
