using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Employee name is required.")]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [DisplayName("Age")]
        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65.")]
        public int Age { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [DisplayName("Phone")]
        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be exactly 11 digits.")]
        public string Phone { get; set; }

        [DisplayName("Designation")]
        [Required(ErrorMessage = "Designation is required.")]
        public string Designation { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }

        [DisplayName("Salary")]
        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, 1000000, ErrorMessage = "Salary must be a positive value.")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; } = true;
        public string Role { get; set; } = "user";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
