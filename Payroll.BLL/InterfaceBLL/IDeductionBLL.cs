using System;
using System.Collections.Generic;
using System.Text;
using Payroll.BLL.DTO;

namespace Payroll.BLL.InterfaceBLL
{
	public interface IDeductionBLL
	{
		void Insert(DeductionDTO deductionDTO);
		void Update(DeductionDTO deductionDTO);
		void Delete(int id);
		IEnumerable<DeductionDTO> GetAll();
		IEnumerable<DeductionDTO> GetDeductionWithPositionName();
		DeductionDTO GetADeductionById(int deduction_id);
		DeductionDTO GetDeductionByPositionId(int position_id);
	}

}
