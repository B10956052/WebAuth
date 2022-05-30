using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class LoginUser
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        ///<summary>
        ///是否停用
        ///</summary>
        public bool IsDisable { get; set; }
    }
}
