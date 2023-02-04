using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Day8.Models
{
    public class Project
    {

        [Key]
        public int Number { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        [ForeignKey("department")]
        public int? department { get; set; }
        public virtual Department? Department { get; set; }

        public List<WorksOnProject>? WorksOnProjects { get; set; }
    }
}
