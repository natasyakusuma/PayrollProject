using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Payroll.BO;

namespace Payroll.DAL.InterfaceDAL
{
	public interface IUser : ICrud <BOUser>
	{
		IEnumerable<BOUser> GetByName(string name);
		//Function to Login
		BOUser Login(string username, string password);

	}
}
