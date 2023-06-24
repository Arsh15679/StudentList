using CRUD_BO_MVC.Transaction;
using CRUD_DL_MVC.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_BL_MVC.Transaction
{
	public class StudentBL : IStudentBL
	{
		public StudentDL studentDL;
		public StudentBL(StudentDL _studentDL)
		{
			studentDL = _studentDL;
		}
		public List<StudentBO> Get_Student_List()
		{
			try
			{
				DataSet ds = studentDL.Get_Student_List();
				DataTable dt = ds.Tables[0];
				List<StudentBO> oStudent_List = new List<StudentBO>();

				if (ds.Tables[0].Rows.Count > 0)
				{
					foreach (DataRow row in dt.Rows)
					{
						StudentBO olist = new StudentBO();

						olist.Id = Convert.ToInt32(row["Id"].ToString());
						olist.name = row["Name"].ToString();
						olist.college = row["College"].ToString();

						oStudent_List.Add(olist);
					}

				}
				return oStudent_List;
			}
			catch (Exception exe)
			{

				throw;
			}
		}

		public bool Save_Student_List(StudentBO input)
		{
			try
			{
				bool ds = studentDL.Save_Student_List(input);
				if (ds)
					return true;
				else
					return false;
			}
			catch (Exception exe)
			{

				throw;
			}
		}

		public StudentBO Get_Student_List_By_Id(StudentBO input)
		{
			try
			{
				DataSet ds = studentDL.Get_Student_List_By_Id(input);
				DataTable dt = ds.Tables[0];

				if (ds.Tables[0].Rows.Count > 0)
				{
					input.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
					input.name = dt.Rows[0]["Name"].ToString();
					input.college = dt.Rows[0]["College"].ToString();

				}
				return input;
			}
			catch (Exception exe)
			{

				throw;
			}
		}

		public bool Update_Student_List(StudentBO input)
		{
			try
			{
				bool ds = studentDL.Update_Student_List(input);
				if (ds)
					return true;
				else
					return false;
			}
			catch (Exception exe)
			{

				throw;
			}
		}

		public bool Delete_By_Id(int id)
		{
			try
			{
				bool ds = studentDL.Delete_By_Id(id);
				if (ds)
					return true;
				else
					return false;
			}
			catch (Exception exe)
			{

				throw;
			}
		}
	}

	public interface IStudentBL
	{
		List<StudentBO> Get_Student_List();

		bool Save_Student_List(StudentBO input);

		StudentBO Get_Student_List_By_Id(StudentBO input);

		bool Update_Student_List(StudentBO input);

		bool Delete_By_Id(int id);
	}

}
