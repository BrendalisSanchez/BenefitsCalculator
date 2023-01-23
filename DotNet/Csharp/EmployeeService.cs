using Sabio.Data;
using Sabio.Data.Providers;
using Sabio.Models;
using Sabio.Models.Domain.Employees;
using Sabio.Models.Domain.Users;
using Sabio.Models.Requests.Employees;
using Sabio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabio.Services
{
	public class EmployeeService : IEmployeeService
	{
		IDataProvider _data = null;


		public EmployeeService(IDataProvider data)
		{
			_data = data;
		}
				
		public Employee Get(int id)
		{
			string procName = "[dbo].[Employees_SelectById]";

			employee employee = null;

			_data.ExecuteCmd(procName, delegate (SqlParameterCollection col)
			{
				col.AddWithValue("@Id", id);
			}
			, delegate (IDataReader reader, short set)
			{
				employee = MapSingleEmployee(reader);
			}
			);
			return employee;
		}

		public List<Employee> GetAll()
		{
			List<Employee> list = null;

			string procName = "[dbo].[Employees_SelectAll]";

			_data.ExecuteCmd(procName, inputParamMapper: null
				, singleRecordMapper: delegate (IDataReader reader, short set)
				{
					Employee employees = MapSingleEmployee(reader);

					if (list == null)
					{
						list = new List<employee>();
					}
					list.Add(employees);
				});
			return list;
		}

		public int Add(EmployeeAddRequest model)
		{
			int id = 0;

			string procName = "[dbo].[Employees_Insert]";
			_data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection col)
			{
				SqlParameter idOut = new SqlParameter("@Id", SqlDbType.Int);
				idOut.Direction = ParameterDirection.Output;

				col.Add(idOut);

				AddCommonParams(model, col);
			}
			, returnParameters: delegate (SqlParameterCollection returnCollection)
			{
				object oldId = returnCollection["@Id"].Value;

				int.TryParse(oldId.ToString(), out id);
			});
			return id;
		}

		public void Update(EmployeeUpdateRequest model, int Id)
		{
			string procName = "[dbo].[Employees_Update]";
			_data.ExecuteNonQuery(procName,
				inputParamMapper: delegate (SqlParameterCollection col)
				{
					col.AddWithValue("@Id", model.Id);
					AddCommonParams(model, col);
				},
				returnParameters: null);
		}

		private static Employee MapSingleemployee(IDataReader reader)
		{
			Employee employee = new Employee();

			int startingIndex = 0;

			employee.Id = reader.GetInt32(startingIndex++);
			employee.EmployeeNumber = reader.GetInt32(startingIndex++);
			employee.FirstName = reader.GetSafeString(startingIndex++);
			employee.MiddleName = reader.GetSafeString(startingIndex++);
			employee.LastName = reader.GetSafeString(startingIndex++);
			employee.Dependents = reader.GetInt32(startingIndex++);
			employee.Paycheck = reader.GetInt32(startingIndex++);
			employee.Status = reader.GetSafeString(startingIndex++);

			return employee;
		}

		private static void AddCommonParams(EmployeeAddRequest model, SqlParameterCollection col)
		{
			col.AddWithValue("@EmployeeNumber", model.EmployeeNumber);
			col.AddWithValue("@FirstName", model.FirstName);
			col.AddWithValue("@MiddleName", model.MiddleName);
			col.AddWithValue("@LastName", model.LastName);
			col.AddWithValue("@Dependents", model.Dependents);
			col.AddWithValue("@Paycheck", model.Paycheck);
			col.AddWithValue("@Status", model.Status);
		}

		#endregion

	}
}
