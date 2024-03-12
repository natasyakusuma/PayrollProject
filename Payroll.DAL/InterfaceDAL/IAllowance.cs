using System;
using System.Collections.Generic;
using System.Text;
using Payroll.BO;

namespace Payroll.DAL.InterfaceDAL
{

	public interface IAllowance : ICrud<BOAllowance>
	{
		IEnumerable<BOAllowance> GetAllowanceWithPositionName();

		BOAllowance GetAllowanceByPositionId(int position_id);
		
	}
}
