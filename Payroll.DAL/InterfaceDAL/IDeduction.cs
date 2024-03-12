using System;
using System.Collections.Generic;
using System.Text;
using Payroll.BO;

namespace Payroll.DAL.InterfaceDAL
{
	public interface IDeduction : ICrud<BODeduction>
	{
		IEnumerable<BODeduction> GetDeductionWithPositionName();

		BODeduction GetDeductionByPositionId(int position_id);


	}
}
