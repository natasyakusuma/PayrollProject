using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Payroll.BO;
using Payroll.DAL.InterfaceDAL;

namespace Payroll.DAL
{
	public class UserDAL : IUser
	{
		private string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
		}

		public BOUser Login(string username, string password)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = @"SELECT * FROM Users WHERE username = @Username AND password = @Password";
				var param = new { Username = username, Password = password };

				try
				{
					var result = conn.QueryFirstOrDefault<BOUser>(strSql, param);
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error Login DAL: " + ex.Message);
				}
			}
		}

		public IEnumerable<BOUser> GetByName(string username)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strsql = "SELECT * FROM Users WHERE username LIKE @username";
				var param = new { username = "%" + username + "%" };
				try
				{
					var result = conn.Query<BOUser>(strsql, param);
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error GetByName DAL: " + ex.Message);
				}
			}
		}

		public IEnumerable<BOUser> GetAll()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strql = "SELECT * FROM Users";
				try
				{
					var result = conn.Query<BOUser>(strql);
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error GetAll DAL: " + ex.Message);
				}
			}
		}

		public BOUser GetById(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strsql = "SELECT * FROM Users WHERE user_id = @user_id";
				var param = new { user_id = id };
				try
				{
					var result = conn.QueryFirstOrDefault<BOUser>(strsql, param);
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error GetById DAL: " + ex);
				}
			}
		}

		public void Insert(BOUser obj)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strsql = @"INSERT INTO Users (username, password, role_id) VALUES (@username, @password, @role_id)";
				var param = new { username = obj.username, password = obj.password, role_id = 1 };
				try
				{
					conn.Execute(strsql, param);
				}
				catch (Exception ex)
				{
					throw new Exception("Error Insert DAL: " + ex.Message);
				}
			}
		}

		public void Update(BOUser obj)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strsql = @"UPDATE Users SET username = @username, password = @password, role_id = @role_id WHERE user_id = @user_id";
				var param = new
				{
					user_id = obj.user_id,
					username = obj.username,
					password = obj.password,
					role_id = 1
				};
				try
				{
					var result = conn.Execute(strsql, param);
				}
				catch (Exception ex)
				{
					throw new Exception("Error Update DAL: " + ex.Message);
				}
			}
		}

		public void Delete(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strsql = "DELETE FROM Users WHERE user_id = @user_id";
				var param = new { user_id = id };
				try
				{
					conn.Execute(strsql, param);
				}
				catch (Exception ex)
				{
					throw new Exception("Error Delete DAL: " + ex.Message);
				}
			}
		}
	}
}
