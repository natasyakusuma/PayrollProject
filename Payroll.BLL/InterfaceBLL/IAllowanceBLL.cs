using System;
using System.Collections.Generic;
using System.Text;
using Payroll.BLL.DTO;

namespace Payroll.BLL.InterfaceBLL
{
	public interface IAllowanceBLL 
	{
		void Insert(AllowanceDTO allowanceDTO);
		void Update(AllowanceDTO allowanceDTO);
		void Delete(int id);
		IEnumerable<AllowanceDTO> GetAll();
		IEnumerable<AllowanceDTO> GetAllowanceWithPositionName();
		AllowanceDTO GetAllowanceById(int allowance_id);
		AllowanceDTO GetAllowanceByPositionId(int position_id);
	}
}
