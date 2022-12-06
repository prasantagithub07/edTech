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
    public class LessonRepository : Repository<CourseLesson>, ILessonRepository
    {
        private AppDbContext dbContext
        {
            get { return _dbContext as AppDbContext; }
        }

        public LessonRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<CourseLesson> GetLessonsByTopic(int topicId)
        {
            var Lsn = (from topic in dbContext.CourseTopics
                           join lessons in dbContext.CourseLessons
                           on topic.Id equals lessons.CourseTopicId
                           where topic.Id == topicId
                       select lessons).ToList();
            return Lsn;
        }
    }
}
