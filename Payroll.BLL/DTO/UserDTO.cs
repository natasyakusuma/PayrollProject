using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.BLL.DTO
{
	public class UserDTO
	{
		public int user_id { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public int role_id { get; set; }

		public RoleDTO role { get; set; }
	}
}
