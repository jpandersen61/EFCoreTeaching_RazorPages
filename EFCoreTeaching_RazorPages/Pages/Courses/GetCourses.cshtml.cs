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

        public IEnumerable<Course> Courses { get; set; }
        public GetCoursesModel(ICourseService service)
        {
            courseService=service;
        }
        public void OnGet(int sid)
        {
           Courses = courseService.GetCourses();
        }
    }
}