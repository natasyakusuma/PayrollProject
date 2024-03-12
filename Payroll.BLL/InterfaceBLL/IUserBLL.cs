using System;
using System.Collections.Generic;
using System.Text;
using Payroll.BLL.DTO;

namespace Payroll.BLL.InterfaceBLL
{
	public interface IUserBLL
	{
		void Delete(int id);
		IEnumerable<UserDTO> GetAll();
		UserDTO GetById(int id);
		IEnumerable<UserDTO> GetByName(string name);
		void Insert(UserDTO obj);
		void Update(UserDTO obj);

		//Login
		UserDTO Login(string username, string password);
	}
}
