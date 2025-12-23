using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EmployeeManagement.Models
{
    [Table("EmployeeData")]
    public class Empdata
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Employee first name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "First name can contain only letters")]
        public string? Emp_FristName { get; set; }

        [Required(ErrorMessage = "Employee last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Last name can contain only letters")]
        public string? Emp_LastName { get; set; }

        [Required(ErrorMessage = "Employee email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string? Emp_EmailId { get; set; }

        [Required(ErrorMessage = "Employee phone number is required")]
        [Phone(ErrorMessage = "Enter a valid phone number")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Enter value Only numeric  value")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits")]
        public string? Emp_PhoneNo { get; set; }

        [Required(ErrorMessage = "Employee position is required")]
        public string? Emp_Position { get; set; }

        [Required(ErrorMessage = "Employee department is required")]
        public string? Emp_Dept { get; set; }

        [Required(ErrorMessage = "Employee salary is required")]
        [Range(1000, 1000000, ErrorMessage = "Salary must be between 1,000 and 1,000,000")]
        public double Emp_Salary { get; set; }



    }
    [Table("UserLogin")]
    public class LoginModel
    {
        [Key]
        [Required (ErrorMessage ="Enter UserName")]
        public string UserId { get; set; }
        [Required(ErrorMessage="Enter Password")]
        public string Password { get; set; }


    }


    }
