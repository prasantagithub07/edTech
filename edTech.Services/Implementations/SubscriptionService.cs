using edTech.DAL.Interfaces;
using edTech.DomainModels.Entities;
using edTech.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTech.Services.Implementations
{
    public class SubscriptionService : Service<Subscription>, ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepo;
        public SubscriptionService(IRepository<Subscription> repo, ISubscriptionRepository subscriptionRepo) : base(repo)
        {
            _subscriptionRepo = subscriptionRepo;
        }

        public IEnumerable<Course> GetSubscribedCourses(int UserId)
        {
            return _subscriptionRepo.GetSubscribedCourses(UserId); 
        }

        public Subscription GetUserSubscription(int UserId, int CourseId)
        {
            Subscription subscription = _subscriptionRepo.GetUserSubscription(UserId, CourseId);    
            return subscription;
        }
    }
}
