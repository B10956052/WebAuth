using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Student: IBaseData
    {

        public Student()
        {
        }
        public Student(string studentNo,string studentName,string githubLink)
        {
            this.studentNo = studentNo;
            this.studentName = studentName;
            this.githubLink = githubLink;
        }

        [Key]
        public string studentNo { get; set; }


        [Required(ErrorMessage ="姓名不可空白")]
        public string studentName { get; set; }


        [MinLength(10, ErrorMessage ="長度不可小於10")]
        public string githubLink { get; set; }


        public bool isDelete { get; set; }
        public DateTime creDateTime { get; set; }
        public DateTime updateDateTime { get; set; }
    }

    
}
