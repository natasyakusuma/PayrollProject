using System;
using System.Collections.Generic;
using System.Text;
using Payroll.BO;

namespace Payroll.DAL.InterfaceDAL
{
	public interface IRole : ICrud <BORole>
	{
		void InsertByName(string name);

	}
}
