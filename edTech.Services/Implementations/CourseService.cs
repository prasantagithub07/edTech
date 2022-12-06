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
    public class CourseService : Service<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IRepository<Mentor> _mentorRepo;
        private readonly ITopicRepository _topicRepo;
        public CourseService(IRepository<Course> repo, ICourseRepository courseRepo, IRepository<Mentor> mentorRepo, ITopicRepository topicRepo) : base(repo)
        {
            _courseRepo = courseRepo;
            _mentorRepo = mentorRepo;
            _topicRepo = topicRepo;
        }

        public Course GetCourseWithLessons(string Url)
        {
            Course course = _courseRepo.GetCourseByUrl(Url);
            course.Mentor = _mentorRepo.Find(course.MentorId);
            course.CourseTopics = _topicRepo.GetTopicsByCourse(course.Id).ToList();
            return course;
        }
    }
}
