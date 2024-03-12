using System;
using System.Collections.Generic;
using System.Text;
using Payroll.BLL.DTO;
using Payroll.BLL.InterfaceBLL;
using Payroll.DAL.InterfaceDAL;
using Payroll.DAL;
using Payroll.BO;

namespace Payroll.BLL
{
	public class UserBLL : IUserBLL
	{
		public readonly IUser _userDAL;
		public UserBLL()
		{
			_userDAL = new UserDAL();
		}

		public void Delete(int id)
		{
			if (id <= 0)
			{
				throw new Exception("ID is required");
			}

			try
			{
				_userDAL.Delete(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error Delete User BLL: " + ex.Message);
			}
		}

		public IEnumerable<UserDTO> GetAll()
		{
			List<UserDTO> result = new List<UserDTO>();
			var data = _userDAL.GetAll();
			foreach (var item in data)
			{
				result.Add(new UserDTO
				{
					user_id = item.user_id,
					username = item.username,
					password = item.password,
					role_id = item.user_id
				});; 
			}
			return result;
		}

		public UserDTO GetById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<UserDTO> GetByName(string name)
		{
			throw new NotImplementedException();
		}

		public void Insert(UserDTO obj)
		{
			throw new NotImplementedException();
		}

		public UserDTO Login(string username, string password)
		{
			try
			{
				BOUser boUser = _userDAL.Login(username, password);

				// Assuming UserDTO has properties similar to BOUser, you need to map them here
				UserDTO userDTO = new UserDTO
				{
					// Map properties from BOUser to UserDTO
					user_id = boUser.user_id,
					username = boUser.username,
					// Map other properties as needed
				};

				return userDTO;
			}
			catch (Exception ex)
			{
				throw new Exception("Error Login User BLL: " + ex.Message);
			}
		}


		public void Update(UserDTO obj)
		{
			throw new NotImplementedException();
		}
	}
}
