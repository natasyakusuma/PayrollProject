using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Payroll.BO;
using Payroll.DAL.InterfaceDAL;

namespace Payroll.DAL
{
	public class DeductionDAL : IDeduction
	{
		private string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
		}

		public void Delete(int deduction_id)
		{
			if (deduction_id <= 0)
			{
				throw new ArgumentException("ID is required");
			}

			try
			{
				using (SqlConnection conn = new SqlConnection(GetConnectionString()))
				{
					var strSql = "DELETE FROM Deduction WHERE deduction_id = @deduction_id";
					var param = new { deduction_id };
					conn.Execute(strSql, param);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Error Delete DAL: " + ex.Message);
			}
		}

		public IEnumerable<BODeduction> GetAll()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "SELECT * FROM Deduction";
				var result = conn.Query<BODeduction>(strSql);
				return result;
			}
		}

		public BODeduction GetById(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "SELECT * FROM Deduction WHERE deduction_id = @deduction_id";
				var param = new { deduction_id = id };
				var result = conn.QueryFirstOrDefault<BODeduction>(strSql, param);
				return result;
			}
		}

		public void Insert(BODeduction obj)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "INSERT INTO Deduction (deduction_name, deduction_amount) VALUES (@DeductionName, @DeductionAmount)";
				var param = new
				{
					deduction_name = obj.deduction_name,
					DeductionAmount = obj.deduction_amount
				};
				conn.Execute(strSql, param);
			}
		}

		public void Update(BODeduction obj)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strSql = "UPDATE Deduction SET deduction_name = @deduction_name, deduction_amount = @deduction_amount WHERE deduction_id = @deduction_id";
				var param = new
				{
					deduction_id = obj.deduction_id,
					deduction_name = obj.deduction_name,
					deduction_amount = obj.deduction_amount,
					position_id = obj.position_id
				};
				conn.Execute(strSql, param);
			}
		}


		public IEnumerable<BOAllowance> GetDeductionWithPositionName()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strsql = @"SELECT D.deduction_id, D.deduction_name, D.deduction_amount, D.position_id, P.position_name
               FROM Deduction D
               INNER JOIN Position P ON D.position_id = P.position_id";
				List<BOAllowance> deductions = new List<BOAllowance>();
				SqlCommand cmd = new SqlCommand(strsql, conn);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						var deduction = new BOAllowance()
						{
							allowance_id = int.Parse(reader["deduction_id"].ToString()),
							allowance_name = reader["deduction_name"].ToString(),
							allowance_amount = decimal.Parse(reader["deduction_amount"].ToString()),
							position_id = int.Parse(reader["position_id"].ToString()),

							position = new BOPosition
							{
								position_id = int.Parse(reader["position_id"].ToString()),
								position_name = reader["position_name"].ToString()
							}
						};

						deductions.Add(deduction);
					}
				}
				return deductions;
			}
		}


		public BODeduction GetDeductionByPositionId(int position_id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<BODeduction> IDeduction.GetDeductionWithPositionName()
		{
			throw new NotImplementedException();
		}
	}
}
