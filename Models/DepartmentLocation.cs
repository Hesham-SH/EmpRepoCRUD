using System.ComponentModel.DataAnnotations.Schema;

namespace Day8.Models
{
    public class DepartmentLocation
    {
        public string Location { get; set; }

        [ForeignKey("Department")]
        public int DeptNumber { get; set; }
        public virtual Department? Department { get; set; }
    }
}
