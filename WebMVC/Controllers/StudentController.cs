using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using WebMVC.Service;

namespace WebMVC.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index(int nowPage = 1)
        {
            int count = 10;
            int offset = (nowPage - 1) * count;

            var (total,list) = _studentService.GetStudents(offset, count);

            ViewData["total"] = total;
            ViewData["nowPage"] = nowPage;

            return View(list);
        }

        public IActionResult Update(string studentNo)
        {
            var student = _studentService.GetStudentByStudentNo(studentNo);

            if(student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.UpdateStudent(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Delete(string studentNo)
        {
            var student = _studentService.GetStudentByStudentNo(studentNo);
            if(student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string studentNo)
        {
            _studentService.DeleteStudent(studentNo);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Index(Dictionary<string, string> queryDic, int nowPage = 1)
        {
            int count = 10;
            int offset = (nowPage - 1) * count;
            var (total, list) = _studentService.GetStudents(offset, count, queryDic);

            ViewData["Total"] = total;
            ViewData["nowPage"] = nowPage;

            ViewData["query_studentName"] = queryDic["studentName"];
            ViewData["query_studentNo"] = queryDic["studentNo"];
            ViewData["query_githubLink"] = queryDic["githubLink"];
            return View(list);
        }
    }
}
