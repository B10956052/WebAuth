using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Service
{
    public interface IStudentService
    {
        public List<Student> GetStudents();

        (int total, List<Student>) GetStudents(int offset, int count);

        (int total, List<Student>) GetStudents(int offset, int count, Dictionary<string, string> queryDic);

        Student GetStudentByStudentNo(string studentNo);

        bool UpdateStudent(Student student);

        bool DeleteStudent(string studentNo);
    }

}
