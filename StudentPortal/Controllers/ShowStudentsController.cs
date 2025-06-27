using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;

namespace StudentPortal.Controllers
{
    public class ShowStudentsController : Controller
    {
        private readonly ApplicationDBContext dBContext;

        public ShowStudentsController(ApplicationDBContext dBContext) {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public async Task<IActionResult> AllStudents() { 

            var student = await dBContext.Students.ToListAsync();
            return View(student);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id) {
            var student = await dBContext.Students.FindAsync(id);
            if (student is not null)
            {
                dBContext.Students.Remove(student);
                await dBContext.SaveChangesAsync();
            }
            await dBContext.SaveChangesAsync();
            TempData["delete_msg"] = student?.Name + " has been deleted successfully!.";
            return RedirectToAction("AllStudents", "ShowStudents");
        }
    }
}
