using System;
using System.Collections.Generic;
using System.Text;
using Payroll.BLL.DTO;
using Payroll.BO;

namespace Payroll.BLL.InterfaceBLL
{
	public interface IRoleBLL
	{
		void InsertByName(string name);
		void Update(RoleDTO obj);
		void Delete(int id);
		IEnumerable<RoleDTO> GetAll();
		RoleDTO GetById(int role_id);
		


	}
}
