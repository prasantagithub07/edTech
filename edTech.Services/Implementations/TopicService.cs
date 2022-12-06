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
    public class TopicService : Service<CourseTopic>, ITopicService
    {
        private readonly ITopicRepository _topicRepo;
        public TopicService(IRepository<CourseTopic> repo, ITopicRepository topicRepo) : base(repo)
        {
            _topicRepo = topicRepo; 
        }

        public IEnumerable<CourseTopic> GetAllTopics()
        {
            return _topicRepo.GetAllTopics();
        }

        public IEnumerable<CourseTopic> GetTopicsByCourse(int CourseId)
        {
            return _topicRepo.GetTopicsByCourse(CourseId);
        }
    }
}
