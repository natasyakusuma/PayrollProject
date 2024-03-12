using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DAL.InterfaceDAL
{
	public interface ICrud
	{
		IEnumerable<T> GetAll<T>();
		T GetById<T>(int id);
		void Insert<T>(T obj);
		void Update<T>(T obj);
		void Delete<T>(int id);

	}
}
