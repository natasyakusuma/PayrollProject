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
	public class PositionDAL : IPosition
	{
		private string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
		}

		public IEnumerable<BOPosition> GetAll()
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strql = "SELECT * FROM Position";
				var result = new List<BOPosition>();
				result = conn.Query<BOPosition>(strql).AsList();
				return result;
			}

		}

		public BOPosition GetById(int id)
		{
			using (SqlConnection conn = new SqlConnection(GetConnectionString()))
			{
				var strql = "SELECT * FROM position WHERE position_id = @position_id";
				var param = new { position_id = id };
				var result = conn.QueryFirstOrDefault<BOPosition>(strql, param);
				return result;
			}
		}

		public void Update(BOPosition obj)
		{
			throw new NotImplementedException();
		}



		public void Insert(BOPosition obj)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
