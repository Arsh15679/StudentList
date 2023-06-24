using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_BO_MVC.Transaction
{
	public class StudentBO
	{
		public int Id { get; set; }
		public string name { get; set; }
		public string college { get; set; }

	}
	public class StudentList
	{
		public List<StudentBO> GetStudentList { get; set; }

	}
}
