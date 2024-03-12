using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.BLL.DTO
{
	public class AllowanceDTO
	{
		public int allowance_id { get; set; }
		public string allowance_name { get; set; }
		public decimal allowance_amount { get; set; }
		public int position_id { get; set; }
		public string position_name { get; set; }

		public PositionDTO position { get; set; }
	}
}
