using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeApplication
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Employee Name")]
        public string Name { get; set; }

        [DisplayName("Employee Email")]
        public string Email { get; set; }

        [DisplayName("Employee Id")]
        public string EmployeeId { get; set; }


        [DisplayName("Subject")]
        [MaxLength(200, ErrorMessage = "Message should be less than 200 words.")]
        public string Subject { get; set; }

        [DisplayName("Employee Message")]
        [Required(ErrorMessage = "Meassage is required.")]
        [MaxLength(200, ErrorMessage = "Message should be less than 200 words.")]
        public string Message { get; set; }

        [DisplayName("Admin Reply")]
        public string Reply { get; set; }

        [DisplayName("Application Status")]
        public string Status { get; set; } = "Pending";


    }
}