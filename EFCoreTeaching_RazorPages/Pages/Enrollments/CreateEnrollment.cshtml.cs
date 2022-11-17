using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCoreTeaching_RazorPages.Services.Interface;
using EFCoreTeaching_RazorPages.Models;

namespace EFCoreTeaching_RazorPages.Pages.Enrollments
{
    public class CreateEnrollmentModel : PageModel
    {
        ICourseService courseService;  
        IStudentService studentService;
        IEnrollmentService enrollmentService;

        public Student Student { get; set; }

        public Course Course { get; set; }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public CreateEnrollmentModel(ICourseService cService, 
                                     IStudentService sService, 
                                     IEnrollmentService eService)
        {
            courseService = cService;
            studentService = sService;
            enrollmentService = eService;
        }
        public void OnGet(int cid, int sid)
        {
            Course = courseService.GetCourse(cid);
            Student = studentService.GetStudent(sid);
            Enrollment = new Enrollment() { CourseId = cid, StudentId = sid };
        }

        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            enrollmentService.AddEnrollment(Enrollment);
            return RedirectToPage("GetEnrollments");

        }
    }
}
