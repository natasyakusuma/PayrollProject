using System;
using System.Collections.Generic;
using System.Text;
using Payroll.BLL.DTO;

namespace Payroll.BLL.InterfaceBLL
{
	public interface IPositionBLL
	{
		void Insert(PositionDTO positionDTO);
		void Update(PositionDTO positionDTO);
		void Delete(int id);
		IEnumerable<PositionDTO> GetAll();


	}
}
