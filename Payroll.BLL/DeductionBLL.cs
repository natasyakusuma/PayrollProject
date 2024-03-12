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
	public class DeductionBLL : IDeductionBLL
	{
		public readonly IDeduction _deductionDAL;

		public DeductionBLL()
		{
			_deductionDAL = new DeductionDAL();
		}

		public void Delete(int deduction_id)
		{
			if (deduction_id <= 0)
			{
				throw new Exception("Id is required");
			}

			try
			{
				_deductionDAL.Delete(deduction_id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error Delete BLL: " + ex.Message);
			}
		}

		public DeductionDTO GetADeductionById(int deduction_id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DeductionDTO> GetAll()
		{
			List<DeductionDTO> result = new List<DeductionDTO>();
			var data = _deductionDAL.GetAll();
			foreach (var item in data)
			{
				result.Add(new DeductionDTO
				{
					deduction_id = item.deduction_id,
					deduction_name = item.deduction_name,
					deduction_amount = (decimal)item.deduction_amount,
					position_id = item.position_id
				});
			}
			return result;
		}

		public DeductionDTO GetAllowanceById(int deduction_id)
		{
			throw new NotImplementedException();
		}

		public DeductionDTO GetAllowanceByPositionId(int position_id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DeductionDTO> GetAllowanceWithPositionName()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DeductionDTO> GetDeductionById(int deduction_id)
		{
			var deductionFromDAL = _deductionDAL.GetById(deduction_id);

			if (deductionFromDAL == null)
			{
				throw new ArgumentException($"Data deduction with id: {deduction_id} not found");
			}

			DeductionDTO deductionDto = new DeductionDTO
			{
				deduction_id = deductionFromDAL.deduction_id,
				deduction_name = deductionFromDAL.deduction_name,
				deduction_amount = (decimal)deductionFromDAL.deduction_amount,
				position_id = deductionFromDAL.position_id,
				position_name = deductionFromDAL.position.position_name
			};

			return new List<DeductionDTO> { deductionDto };
		}

		public IEnumerable<DeductionDTO> GetDeductionByPositionId(int position_id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DeductionDTO> GetDeductionWithPositionName()
		{
			List<DeductionDTO> deductionDto = new List<DeductionDTO>();
			var deductionFromDAL = _deductionDAL.GetDeductionWithPositionName();
			foreach (var item in deductionFromDAL)
			{
				deductionDto.Add(new DeductionDTO
				{
					deduction_id = item.deduction_id,
					deduction_name = item.deduction_name,
					deduction_amount = (decimal)item.deduction_amount,
					position_id = item.position_id,
					position_name = item.position.position_name
				});
			}
			return deductionDto;
		}

		public void Insert(DeductionDTO deductionDTO)
		{
			if (string.IsNullOrEmpty(deductionDTO.deduction_name))
			{
				throw new Exception("Deduction name is required");
			}

			try
			{
				var newDeduction = new BODeduction
				{
					deduction_name = deductionDTO.deduction_name,
					deduction_amount = deductionDTO.deduction_amount,
					position_id = deductionDTO.position_id
				};
				_deductionDAL.Insert(newDeduction);
			}
			catch (Exception ex)
			{
				throw new Exception("Error Insert BLL: " + ex.Message);
			}
		}

		public void Update(DeductionDTO deductionDTO)
		{
			throw new NotImplementedException();
		}

		DeductionDTO IDeductionBLL.GetDeductionByPositionId(int position_id)
		{
			throw new NotImplementedException();
		}
	}
}
