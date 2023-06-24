using CRUD_BL_MVC.Transaction;
using CRUD_BO_MVC.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_With_MVC.Controllers.Transaction
{
	public class StudentController : Controller
	{
		public IStudentBL studentBl;

		public StudentController(IStudentBL _studentBL)
		{
			studentBl = _studentBL;
		}

		[HttpGet]
		public IActionResult StudentList()
		{
			StudentList list = new StudentList();

			list.GetStudentList = studentBl.Get_Student_List();
			return View("~/Views/Transaction/Student/Student.cshtml",list);
		}

		[HttpGet]
		public IActionResult StudentCreate()
		{
			return View("~/Views/Transaction/Student/Create.cshtml");
		}

		[HttpPost]
		public IActionResult StudentCreate(StudentBO input)
		{
			bool success = studentBl.Save_Student_List(input);
			if (success == true)
			{
				TempData["SuccessMessage"] = "Item Created Successfully";
				return RedirectToAction("StudentList");
			}
			else
			{
				return RedirectToAction("Index");
			}
			
		}

		[HttpGet]
		public IActionResult Get_Student_List_By_Id(StudentBO input)
		{
			
			var data = studentBl.Get_Student_List_By_Id(input);

			return View("~/Views/Transaction/Student/Edit.cshtml",data);

		}

		[HttpPost]
		public IActionResult Update_Student_By_Id(StudentBO input)
		{

			bool data = studentBl.Update_Student_List(input);
			if (data == true)
			{
				TempData["SuccessMessage"] = "Item Updated Successfully";
				return RedirectToAction("StudentList");
			}
			else
			{
				return View();
			}

		}

		[HttpPost]
		public IActionResult Delet_By_Id(int id)
		{

			bool data = studentBl.Delete_By_Id(id);
			if (data == true)
			{
				TempData["SuccessMessage"] = "Item Deleted Successfully";
				return RedirectToAction("StudentList");
			}
			else
			{
				return View();
			}

		}
	}
}
