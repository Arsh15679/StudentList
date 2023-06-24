using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_BO_MVC.Transaction;

namespace CRUD_DL_MVC.Transaction
{
	
	public class StudentDL
	{
		public IConfiguration configuration;
		public string conStr { get; set; }
		public SqlConnection con;
		public StudentDL(IConfiguration _configuration)
		{
			configuration = _configuration;
			conStr = configuration.GetConnectionString("CRUDConnection");
		}
		
		public DataSet Get_Student_List()
		{
			con = new SqlConnection(conStr);
			con.Open();
			SqlCommand cmd = new SqlCommand("",con);
			cmd.CommandText = "Get_Student_List";
			cmd.CommandType = CommandType.StoredProcedure;
			
			cmd.ExecuteNonQuery();
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(ds);
			con.Close();

			return ds;
			
		}

		public bool Save_Student_List(StudentBO input)
		{
			con = new SqlConnection(conStr);
			con.Open();
			SqlCommand cmd = new SqlCommand("", con);
			cmd.CommandText = "Pr_Insert_Update_StudentList";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@Name", SqlDbType.NVarChar,50).Value = input.name;
			cmd.Parameters.Add("@College", SqlDbType.NVarChar,200).Value = input.college;
			int id = cmd.ExecuteNonQuery();
			if (id > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
			con.Close();


		}

		public DataSet Get_Student_List_By_Id(StudentBO input)
		{
			con = new SqlConnection(conStr);
			con.Open();
			SqlCommand cmd = new SqlCommand("", con);
			cmd.CommandText = "GET_STUDENT_EDIT";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@Id", SqlDbType.Int).Value = input.Id;

			cmd.ExecuteNonQuery();
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(ds);
			con.Close();

			return ds;

		}

		public bool Update_Student_List(StudentBO input)
		{
			try
			{
				con = new SqlConnection(conStr);
				con.Open();
				SqlCommand cmd = new SqlCommand("", con);
				cmd.CommandText = "Pr_Insert_Update_StudentList_By_Id";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.Int).Value = input.Id;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = input.name;
				cmd.Parameters.Add("@College", SqlDbType.NVarChar, 200).Value = input.college;
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception exe)
			{
				return false;
			}
			
			
			con.Close();


		}

		public bool Delete_By_Id(int id)
		{
			try
			{
				con = new SqlConnection(conStr);
				con.Open();
				SqlCommand cmd = new SqlCommand("", con);
				cmd.CommandText = "Delete_By_Id";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception exe)
			{
				return false;
			}


			con.Close();


		}

	}
}
