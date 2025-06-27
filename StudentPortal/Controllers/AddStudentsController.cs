using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Enitity;

namespace StudentPortal.Controllers
{
    public class AddStudentsController : Controller
    {
        private readonly ApplicationDBContext dBContext;

        public AddStudentsController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStdViewModel viewModel)
        {

            var student = new Student { 
            Name = viewModel.Name,
            Email = viewModel.Email,
            Phone = viewModel.Phone,
            isActive = true,
            };

            await dBContext.Students.AddAsync(student);
            await dBContext.SaveChangesAsync();
            TempData["Message"] = "Student added successfully!";
            return RedirectToAction("Add");

        }
    }
}
