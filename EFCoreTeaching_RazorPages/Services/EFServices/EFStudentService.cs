using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTeaching_RazorPages.Services.EFServices
{
     public class EFStudentService: IStudentService
    {
        RegistrationDBContext context;
        public EFStudentService(RegistrationDBContext service)
        {
            context = service;
        }
        public IEnumerable<Student> GetStudents()
        {
            return context.Students;
        }
        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public Student GetStudent(int id)
        {
           var student = context.Students
          .Include(s => s.Enrollments).ThenInclude(c => c.Course)
          .AsNoTracking()
          .FirstOrDefault(m => m.StudentId == id);
          return student;
        }

        public void DeleteStudent(int id)
        {
            IEnumerable<Enrollment> enrollments = context.Enrollments.Where(e => e.StudentId == id);

            if (enrollments != null)
            {
                context.Enrollments.RemoveRange(enrollments);
            }
            
            Student stundentToBeDeleted = context.Students.FirstOrDefault(m => m.StudentId == id);
            context.Students.Remove(stundentToBeDeleted);
            
            context.SaveChanges();
        }
    }

}

