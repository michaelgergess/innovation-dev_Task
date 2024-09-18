using innovation_dev_Task.Application.DTOs;
using innovation_dev_Task.Application.Services;
using innovation_dev_Task.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace innovation_dev_Task.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // Displays all students
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students);
        }

        // Create Student - GET
        public async Task<IActionResult> Create()
        {
            var subjects = await _studentService.GetAllSubjectsAsync();
            ViewBag.Subjects = subjects;
            return View();
        }

        // Create Student - POST
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                var subjects = await _studentService.GetAllSubjectsAsync();
                ViewBag.Subjects = subjects;
                return View(studentDto);
            }

          await _studentService.AddStudentAsync(studentDto);
          
            return RedirectToAction(nameof(Index));
        }

        // Create Subject - GET
        public IActionResult CreateSubject()
        {
            return View();
        }

        // Create Subject - POST
        [HttpPost]
        public async Task<IActionResult> CreateSubject(CreateSubjectDto subjectDto)
        {
            if (!ModelState.IsValid)
            {
                return View(subjectDto);
            }

            await _studentService.AddSubjectAsync(subjectDto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public async Task<IActionResult> ValidateStudentName(string name)
        {
            var studentExists = await _studentService.ValidateStudentName(name);
            if (studentExists)
            {
                return Json($"Student with name '{name}' already exists.");
            }
            return Json(true);
        }
        [HttpGet]
        public async Task<IActionResult> ValidateSubjectName(string name)
        {
           var subjectExists = await _studentService.ValidateSubjectName(name);
            if (subjectExists)
            {
                return Json($"Student with name '{name}' already exists.");
            }
            return Json(true);
        }
    }
}
