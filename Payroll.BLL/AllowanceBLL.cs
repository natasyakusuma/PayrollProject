using System;
using System.Collections.Generic;
using System.Text;
using Payroll.BLL.DTO;
using Payroll.BLL.InterfaceBLL;
using Payroll.BO;
using Payroll.DAL;
using Payroll.DAL.InterfaceDAL;

namespace Payroll.BLL
{
	public class AllowanceBLL : IAllowanceBLL
	{
		public readonly IAllowance _allowanceDAL;

		public AllowanceBLL()
		{
			_allowanceDAL = new AllowanceDAL();
		}

		public void Delete(int allowance_id)
		{
			if (allowance_id <= 0)
			{
				throw new Exception("Id is required");

			}
			try
			{
				_allowanceDAL.Delete(allowance_id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error Delete BLL: " + ex.Message);
			}

		}

		public IEnumerable<AllowanceDTO> GetAll()
		{
			List<AllowanceDTO> result = new List<AllowanceDTO>();
			var data = _allowanceDAL.GetAll();
			foreach (var item in data)
			{
				result.Add(new AllowanceDTO
				{
					allowance_id = item.allowance_id,
					allowance_name = item.allowance_name,
					allowance_amount = (decimal)item.allowance_amount,
					position_id = item.position_id
				});
			}
			return result;
		}

		public AllowanceDTO GetAllowanceById(int allowance_id)
		{
			var allowanceFromDAL = _allowanceDAL.GetById(allowance_id);

			// Periksa apakah data tunjangan ditemukan
			if (allowanceFromDAL == null)
			{
				throw new ArgumentException($"Data allowance with id: {allowance_id} not found");
			}

			try
			{
				AllowanceDTO allowanceDto = new AllowanceDTO
				{
					allowance_id = allowanceFromDAL.allowance_id,
					allowance_name = allowanceFromDAL.allowance_name,
					allowance_amount = allowanceFromDAL.allowance_amount,
					position_id = allowanceFromDAL.position_id
				};

				// Cek apakah positionFromDAL tidak null sebelum mengakses propertinya
				if (allowanceFromDAL.position != null)
				{
					allowanceDto.position_name = allowanceFromDAL.position.position_name;
					allowanceDto.position = new PositionDTO
					{
						position_id = allowanceFromDAL.position.position_id,
						position_name = allowanceFromDAL.position.position_name
					};
				}
				else
				{
					// Handle jika positionFromDAL adalah null
					allowanceDto.position_name = "Position not available";
				}

				return allowanceDto;
			}
			catch (Exception ex)
			{
				throw new Exception("Error GetAllowanceById BLL: " + ex.Message);
			}
		}


		public AllowanceDTO GetAllowanceByPositionId(int position_id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<AllowanceDTO> GetAllowanceWithPositionName()
		{
			List<AllowanceDTO> allowanceDto = new List<AllowanceDTO>();
			var allowanceFromDAL = _allowanceDAL.GetAllowanceWithPositionName();
			foreach (var item in allowanceFromDAL)
			{
				allowanceDto.Add(new AllowanceDTO
				{
					allowance_id = item.allowance_id,
					allowance_name = item.allowance_name,
					allowance_amount = (decimal)item.allowance_amount,
					position_id = item.position_id,
					position_name = item.position.position_name
				});
			}
			return allowanceDto;
		}

		public void Insert(AllowanceDTO allowanceDTO)
		{
			if (string.IsNullOrEmpty(allowanceDTO.allowance_name))
			{
				throw new Exception("Allowance name is required");
			}
			try
			{
				var newAllowance = new BOAllowance
				{
					allowance_name = allowanceDTO.allowance_name,
					allowance_amount = allowanceDTO.allowance_amount,
					position_id = allowanceDTO.position_id
				};
				_allowanceDAL.Insert(newAllowance);
			}
			catch (Exception ex)
			{
				throw new Exception("Error Insert BLL: " + ex.Message);
			}
		}

		public void Update(AllowanceDTO allowanceDTO)
		{
			try
			{
				var allowance = new BOAllowance
				{
					allowance_amount = allowanceDTO.allowance_amount,
					allowance_id = allowanceDTO.allowance_id,
					allowance_name = allowanceDTO.allowance_name,
					position_id = allowanceDTO.position_id,

				};
				_allowanceDAL.Update(allowance);
			}
			catch (Exception ex)
			{
				throw new Exception("Error Update BLL: " + ex.Message);
			}
		}


	}

}
