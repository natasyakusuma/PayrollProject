using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.BLL.DTO
{
	public class DeductionDTO
	{
		public int deduction_id { get; set; }
		public string deduction_name { get; set; }
		public decimal deduction_amount { get; set; }
		public int position_id { get; set; }
		public string position_name { get; set; }

		public PositionDTO position { get; set; }
	}
}
