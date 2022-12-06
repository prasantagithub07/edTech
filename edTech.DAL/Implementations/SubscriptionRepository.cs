using edTech.DAL.Interfaces;
using edTech.DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTech.DAL.Implementations
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        private AppDbContext dbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public SubscriptionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Course> GetSubscribedCourses(int UserId)
        {
            IEnumerable<Course> courses = (from sub in dbContext.Subscriptions
                                           join c in dbContext.Courses
                                           on sub.CourseId equals c.Id
                                           where sub.UserId == UserId
                                           select c).ToList();
            return courses;
        }

        public Subscription GetUserSubscription(int UserId, int CourseId)
        {
            return dbContext.Subscriptions.Where(x=> x.UserId==UserId && x.CourseId == CourseId).FirstOrDefault();
        }
    }
}
