using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Payroll.BLL.DTO;
using Payroll.BLL.InterfaceBLL;
using Payroll.BO;
using Payroll.DAL;
using Payroll.DAL.InterfaceDAL;

namespace Payroll.BLL
{
	public class RoleBLL : IRoleBLL
	{
		public readonly IRole _roleDAL;
		public RoleBLL()
		{
			_roleDAL = new RoleDAL();

		}
		public void Delete(int id)
		{
			if (id <= 0)
			{
				throw new Exception("id is required");
			}
			try
			{
				_roleDAL.Delete(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error Delete BLL: " + ex.Message);
			}
		}

		public IEnumerable<RoleDTO> GetAll()
		{
			List<RoleDTO> result = new List<RoleDTO>();
			var data = _roleDAL.GetAll();
			foreach (var item in data)
			{
				result.Add(new RoleDTO
				{
					role_id = item.role_id,
					role_name = item.role_name
				});
			}
			return result;
		}

		public RoleDTO GetById(int role_id)
		{
			RoleDTO roleDTO = new RoleDTO();
			var roleFromDAL = _roleDAL.GetById(role_id);
			if (roleFromDAL != null)
			{
				roleDTO.role_id = roleFromDAL.role_id;
				roleDTO.role_name = roleFromDAL.role_name;
			}
			else
			{
				throw new Exception("Data not found");
			}
			return roleDTO;
		}

		public void InsertByName(string name)
		{
			if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(name) || name.Length > 50)
			{
				throw new Exception("Name is required and max 50 characters");
			}

			try
			{
				var role = new RoleDTO
				{
					role_name = name
				};
			}
			catch (Exception ex)
			{
				throw new Exception("Error Insert BLL: " + ex.Message);
			}
		}

		public void Update(RoleDTO obj)
		{
			try
			{
				var role = new BORole
				{
					role_id = obj.role_id,
					role_name = obj.role_name
				};
				if (!string.IsNullOrEmpty(role.role_name) || role.role_name.Length > 50)
				{
					throw new Exception("Name is required and max 50 characters");
				}
				_roleDAL.Update(role);
			}
			catch (Exception ex)
			{
				throw new Exception("Error Update BLL: " + ex.Message);
			}

		}

	}
}

