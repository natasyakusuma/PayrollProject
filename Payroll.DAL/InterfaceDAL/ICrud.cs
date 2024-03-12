using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.DAL.InterfaceDAL
{
	public interface ICrud <T>
	{
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Insert(T obj);
		void Update(T obj);
		void Delete(int id);


	}
}
