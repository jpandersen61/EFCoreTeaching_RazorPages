using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;

namespace EFCoreTeaching_RazorPages
{
    public class GetCoursesModel : PageModel
    {
        ICourseService courseService;
        IStudentService studentService;

        public IEnumerable<Course> Courses { get; set; }
        public Student Student { get; set; }
        public GetCoursesModel(ICourseService cService, IStudentService sService)
        {
            courseService=cService;
            studentService=sService;
        }
        public void OnGet(int sid)
        {
           if(sid>0)
           {
                    Student = studentService.GetStudent(sid);
           }
           Courses = courseService.GetCourses();
        }
    }
}