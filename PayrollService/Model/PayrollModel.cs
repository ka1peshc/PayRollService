using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollService.Model
{
    public class PayrollModel
    {
        public int EmpId { get; set; }
        public float BasicPay { get; set; }
        public float Deduction { get; set; }
        public float Taxable { get; set; }
        public float Tax { get; set; }
        public float NetPay { get; set; }
    }
}
