using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using Dapper;
using Payroll.BO;
using Payroll.DAL.InterfaceDAL;

namespace Payroll.DAL
{
	public class AllowanceDAL : IAllowance
	{
		private string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
		}

		public void Delete(int allowance_id)
		{
			if (allowance_id <= 0)
			{
				throw new Exception("Id is required");
			}

			try
			{
				using (SqlConnection conn = new SqlConnection(GetConnectionString()))
				{
					var strsql = "DELETE FROM Allowance WHERE allowance_id = @allowance_id";
					var param = new { allowance_id };

					conn.Execute(strsql, param);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Error Delete DAL: " + ex.Message);
			}
		}


		public IEnumerable<BOAllowance> GetAll()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strql = "SELECT * FROM Allowance";
				var result = new List<BOAllowance>();
				return result;
			}

		}

		public BOAllowance GetById(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strql = "SELECT * FROM Allowance WHERE allowance_id = @allowance_id";
				var param = new { allowance_id = id };
				try
				{
					var result = conn.QueryFirstOrDefault<BOAllowance>(strql, param);
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

			}
		}

		public IEnumerable<BOAllowance> GetAllowanceWithPositionName()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strsql = @"SELECT A.allowance_id, A.allowance_name, A.allowance_amount, A.position_id, P.position_name
                       FROM Allowance A
                       INNER JOIN Position P ON A.position_id = P.position_id";
				List<BOAllowance> allowances = new List<BOAllowance>();
				SqlCommand cmd = new SqlCommand(strsql, conn);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						var allowance = new BOAllowance()
						{
							allowance_id = int.Parse(reader["allowance_id"].ToString()),
							allowance_name = reader["allowance_name"].ToString(),
							allowance_amount = decimal.Parse(reader["allowance_amount"].ToString()),
							position_id = int.Parse(reader["position_id"].ToString()),

							position = new BOPosition
							{
								position_id = int.Parse(reader["position_id"].ToString()),
								position_name = reader["position_name"].ToString()
							}
						};

						allowances.Add(allowance);
					}
				}
				return allowances;
			}
		}


		public void Insert(BOAllowance obj)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "INSERT INTO Allowance (allowance_name, allowance_amount, position_id) VALUES (@AllowanceName, @AllowanceAmount, @PositionId)";
				var param = new
				{
					AllowanceName = obj.allowance_name,
					AllowanceAmount = obj.allowance_amount,
					PositionId = obj.position_id
				};
				try
				{
					conn.Execute(strSql, param);
				}
				catch (SqlException ex)
				{
					// Handle SQL exceptions
					throw new Exception("Error inserting data: " + ex.Message, ex);
				}
				catch (Exception ex)
				{
					// Handle other exceptions
					throw new Exception("Error inserting data: " + ex.Message, ex);
				}
			}
		}




		public void Update(BOAllowance obj)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				string strsql = @"UPDATE Allowance SET allowance_name = @allowance_name, allowance_amount = @allowance_amount, position_id = @position_id WHERE allowance_id = @allowance_id";
				var param = new { allowance_id = obj.allowance_id, allowance_name = obj.allowance_name, allowance_amount = obj.allowance_amount, position_id = obj.position_id };
				try
				{
					conn.Execute(strsql, param);
				}
				catch (Exception ex)
				{
					throw new Exception("Error Update DAL: " + ex.Message);
				}
			}
		}

		public BOAllowance GetAllowanceByPositionId(int position_id)
		{
			throw new NotImplementedException();
		}




		//public void Update(BOAllowance obj)
		//{
		//	using (SqlConnection conn = new SqlConnection(GetConnectionString()))
		//	{
		//		string strsql = @"UPDATE Allowance SET allowance_name = @allowance_name, allowance_amount = @allowance_amount, position_id = @position_id WHERE allowance_id = @allowance_id";
		//		var param = new { allowance_id = obj.allowance_id, allowance_name = obj.allowance_name, allowance_amount = obj.allowance_amount, position_id = obj.position_id };
		//		try
		//		{
		//			conn.Execute(strsql, param);
		//		}
		//		catch (Exception ex)
		//		{
		//			throw new Exception("Error Update DAL: " + ex.Message);
		//		}
		//	}


		//}
	}
}

