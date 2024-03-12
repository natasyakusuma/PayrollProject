using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.BO
{
	public class BODeduction
	{
		public int deduction_id { get; set; }
		public string deduction_name { get; set; }
		public decimal deduction_amount { get; set; }
		public int position_id { get; set; }

		public BOPosition position { get; set; }
	}
}
