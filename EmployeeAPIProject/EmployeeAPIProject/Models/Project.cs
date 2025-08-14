using System.ComponentModel.DataAnnotations;

namespace EmployeeAPIProject.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public IList<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
