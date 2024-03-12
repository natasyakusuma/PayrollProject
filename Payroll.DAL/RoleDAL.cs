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
	public class RoleDAL : IRole
	{
		private string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
		}
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<BORole> GetAll()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strql = "SELECT * FROM Role";
				try
				{
					var result = conn.Query<BORole>(strql);
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error GetAll DAL: " + ex.Message);
				}
			}
		}

		public BORole GetById(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strsql = "SELECT * FROM Role WHERE role_id = @role_id";
				var param = new { role_id = id };
				try
				{
					var result = conn.QueryFirstOrDefault<BORole>(strsql, param);
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception("Error GetById DAL: " + ex.Message);
				}
			}
		}



		public void Update(BORole obj)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strsql = "UPDATE Role SET role_name = @role_name WHERE role_id = @role_id";
				var param = new { role_name = obj.role_name, role_id = obj.role_id };
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

			public void InsertByName(string name)
			{
				using (SqlConnection conn = new SqlConnection(GetConnectionString()))
				{
					var strsql = "INSERT INTO Role (role_name) VALUES (@role_name)";
					var param = new { role_name = name };
					try
					{
						conn.Execute(strsql, param);
					}
					catch (Exception ex)
					{
						throw new Exception("Error InsertByName DAL: " + ex.Message);
					}
				}
			}

			public void Insert(BORole obj)
			{
				throw new NotImplementedException();
			}
		}
	}
