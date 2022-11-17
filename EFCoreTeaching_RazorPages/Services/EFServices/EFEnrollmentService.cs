using EFCoreTeaching_RazorPages.Models;
using EFCoreTeaching_RazorPages.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTeaching_RazorPages.Services.EFServices
{
    /// <summary>
    /// EFEnrollmentService handles enrollment data
    /// </summary>
    public class EFEnrollmentService:IEnrollmentService
    {

        RegistrationDBContext context;
        public EFEnrollmentService(RegistrationDBContext service)
        {
            context = service;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Enrollment> GetEnrollments()
        {
            return context.Enrollments;
        }

        /// <summary>
        /// Add an enrollment
        /// </summary>
        /// <param name="enrollment">Must of class enrollment</param>
        public void AddEnrollment(Enrollment enrollment)
        {
            context.Enrollments.Add(enrollment);    
            context.SaveChanges();
        }
    }
}
