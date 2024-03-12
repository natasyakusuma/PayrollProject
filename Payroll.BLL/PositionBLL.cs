using System;
using System.Collections.Generic;
using System.Text;
using Payroll.BLL.DTO;
using Payroll.BLL.InterfaceBLL;
using Payroll.BO;
using Payroll.DAL;
using Payroll.DAL.InterfaceDAL;

namespace Payroll.BLL
{
	public class PositionBLL : IPositionBLL
	{
		public readonly IPosition _positionDAL;
		public PositionBLL()
		{
			_positionDAL = new PositionDAL();
		}
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PositionDTO> GetAll()
		{
			List<PositionDTO> result = new List<PositionDTO>();
			var data = _positionDAL.GetAll();
			foreach (var item in data)
			{
				result.Add(new PositionDTO
				{
					position_id = item.position_id,
					position_name = item.position_name
				});
			}
			return result;

		}

		public void Insert(PositionDTO positionDTO)
		{
			throw new NotImplementedException();
		}

		public void Update(PositionDTO positionDTO)
		{
			throw new NotImplementedException();
		}
	}
}
