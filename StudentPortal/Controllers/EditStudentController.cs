using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models.Enitity;
using System.Runtime.InteropServices;

namespace StudentPortal.Controllers
{
    public class EditStudentController : Controller
    {
        private readonly ApplicationDBContext dBContext;

        public EditStudentController(ApplicationDBContext dBContext) {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dBContext.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student studentModel) {

            var student =await  dBContext.Students.FindAsync(studentModel.Id);

            if (student is not null) { 
                student.Name = studentModel.Name;
                student.Phone = studentModel.Phone;
                student.Email = studentModel.Email;
                student.isActive = studentModel.isActive;
            }

            await dBContext.SaveChangesAsync();
            TempData["msg"] = studentModel.Name + " has been saved successfully!.";
            return RedirectToAction("AllStudents", "ShowStudents");
        }
    }
}
