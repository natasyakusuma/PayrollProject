using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.BO
{
	public class BOUser
	{
		public int user_id { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public int role_id { get; set; }

		BORole role { get; set; }
	}
}
