using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPIProject.Models
{

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmployeeCode { get; set; }
        public string designation { get; set; }
        public decimal Salary { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project? Projects { get; set; }
    }
    }
