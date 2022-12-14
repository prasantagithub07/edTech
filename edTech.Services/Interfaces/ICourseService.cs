using edTech.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTech.Services.Interfaces
{
    public interface ICourseService: IService<Course>
    {
        Course GetCourseWithLessons(string Url);
    }
}
