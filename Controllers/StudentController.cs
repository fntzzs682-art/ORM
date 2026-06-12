using Microsoft.AspNetCore.Mvc;
using Lesson3_CNLTWeb.Models;

namespace Lesson3_CNLTWeb.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>()
        {
            new Student
            {
                Id = 1,
                Name = "Nguyen Van A",
                Email = "a@gmail.com",
                Phone = "0123456789"
            },
            new Student
            {
                Id = 2,
                Name = "Tran Thi B",
                Email = "b@gmail.com",
                Phone = "0987654321"
            }
        };

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Detail(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            student.Id = students.Max(x => x.Id) + 1;

            students.Add(student);

            TempData["Message"] = "Thêm sinh viên thành công";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var student = students.FirstOrDefault(x => x.Id == model.Id);

            if (student == null)
                return NotFound();

            student.Name = model.Name;
            student.Email = model.Email;
            student.Phone = model.Phone;

            TempData["Message"] = "Cập nhật thành công";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                students.Remove(student);
            }

            TempData["Message"] = "Xóa thành công";

            return RedirectToAction("Index");
        }
    }
}