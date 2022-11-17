using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCoreTeaching_RazorPages.Services.Interface;
using EFCoreTeaching_RazorPages.Models;

namespace EFCoreTeaching_RazorPages.Pages.Courses
{
    public class Course_EnrollmentsModel : PageModel
    {
        ICourseService courseService
;
        public Course_EnrollmentsModel(ICourseService service)
        {
            
            courseService = service;
        }

        public Course Course;


        public IActionResult OnGet(int cid)
        {

            Course = courseService.GetCourse(cid);
            if (Course == null)
            {
                
                return NotFound();
            }

            return Page();
        }
    }
}
