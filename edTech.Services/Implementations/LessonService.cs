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
    public class LessonService : Service<CourseLesson>, ILessonService
    {
        private readonly ILessonRepository _lessonRepo;
        public LessonService(IRepository<CourseLesson> repo, ILessonRepository lessonRepo) : base(repo)
        {
            _lessonRepo = lessonRepo;
        }

        public IEnumerable<CourseLesson> GetLessonsByTopic(int TopicId)
        {
            return _lessonRepo.GetLessonsByTopic(TopicId);  
        }
    }
}
