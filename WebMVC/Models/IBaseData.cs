using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    interface IBaseData
    {
        bool isDelete { get; set; }

        DateTime creDateTime { get; set; }

        DateTime updateDateTime { get; set; }
    }
}
