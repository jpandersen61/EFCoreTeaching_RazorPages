using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTeaching_RazorPages.Services.EFServices
{
    /// <summary>
    /// EFCourseService handles course
    /// </summary>
    public class EFCourseService:ICourseService
    {
        RegistrationDBContext context;
        public EFCourseService(RegistrationDBContext service)
        {
            context = service;
        }

        public IEnumerable<Course> GetCourses()
        {
            return context.Courses.AsNoTracking();
        }

       /// <summary>
       /// Finds a Course on its ID
       /// </summary>
       /// <param name="id"> ID of the course</param>
       /// <returns>Found course</returns>
        public Course GetCourse(int id)
        {
           var course = context.Courses
          .Include(s => s.Enrollments).ThenInclude(c => c.Student)
          .AsNoTracking()
          .FirstOrDefault(m => m.CourseId == id);
           return course;
        }
    }
}
