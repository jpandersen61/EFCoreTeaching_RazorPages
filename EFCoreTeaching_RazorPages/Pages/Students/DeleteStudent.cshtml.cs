using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;

namespace EFCoreTeaching_RazorPages.Pages.Students
{
    public class DeleteStudentModel : PageModel
    {
        public DeleteStudentModel(IStudentService sService )
        {
            studentService=sService;
        }

        IStudentService studentService;
        [BindProperty]
        public Student Student { get; set; }
        public void OnGet(int sid)
        {
            Student = studentService.GetStudent(sid);
        }

        public IActionResult OnPost(int sid)
        {
            studentService.DeleteStudent(sid);
            return RedirectToPage("GetStudents");
        }
    }
}
