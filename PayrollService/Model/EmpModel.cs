using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollService.Model
{
    class EmpModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime StartDate { get; set; }
    }
}
