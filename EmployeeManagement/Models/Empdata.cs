using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagement.Models
{
    [Table("EmployeeData")]
    public class Empdata
    {
        [Key]
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Enter Emplyoee First Name")]
        public string Emp_FristName { get; set; }
        [Required(ErrorMessage = "Enter Emplyoee Last Name")]

        public string Emp_LastName { get; set; }
        [Required(ErrorMessage = "Enter Emplyoee Email Id")]

        public string Emp_EmailId { get; set; }

        [Required(ErrorMessage = "Enter Emplyoee Phone No")]
        public int Emp_PhoneNo { get; set; }
        [Required(ErrorMessage = "Select Emplyoee Position ")]

        public string Emp_Position { get; set; }
        [Required(ErrorMessage ="Select Emplyoee Dept")]

        public string Emp_Dept { get; set; }
        [Required(ErrorMessage = "Enter Emplyoee Salary")]

        public double Emp_Salary { get; set; }



    }
    public class LoginModel
    {
        [Required (ErrorMessage ="Enter UserName")]
        public string Username { get; set; }
        [Required(ErrorMessage="Enter Password")]
        public string Password { get; set; }

    }
    }
