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
    public class TopicRepository : Repository<CourseTopic>, ITopicRepository
    {
        private AppDbContext dbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public TopicRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<CourseTopic> GetAllTopics()
        {
            var topics = (from topic in dbContext.CourseTopics
                          join course in dbContext.Courses
                          on topic.CourseId equals course.Id
                          select new CourseTopic
                          {
                              Id=topic.Id,  
                              TopicName = topic.TopicName,  
                              CourseName=course.Name,
                              IsActive=topic.IsActive
                          }).ToList();
            return topics;
        }

        public IEnumerable<CourseTopic> GetTopicsByCourse(int id)
        {
            //var Topics = dbContext.CourseTopics.Where(c => c.CourseId == id).Include("Lessons").ToList();

            //var Topics2 = dbContext.CourseTopics.Where(c => c.CourseId == id).ToList();

            //var Topics3 = (from topic in dbContext.CourseTopics
                           //where topic.CourseId == id
                           //select topic).ToList();

            var Topics = (from topic in dbContext.CourseTopics
                           where topic.CourseId == id
                           select new CourseTopic
                           {
                               Id = topic.Id,
                               IsActive = topic.IsActive,
                               Lessons = (from lesson in dbContext.CourseLessons
                                          where lesson.CourseTopicId == topic.Id
                                          select lesson).ToList()
                           });

            return Topics;
        }

        public IEnumerable<CourseTopic> GetTopicWithLessons(int id)
        {
            var Topics = (from topic in dbContext.CourseTopics
                          where topic.CourseId == id
                          select topic).ToList();
            return Topics;
        }
    }
}
