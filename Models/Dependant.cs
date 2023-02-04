using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day8.Models
{
    public class Dependant
    {
        //Primary is composite key of (EmpSSN, Name)
        public string Name { get; set; }
        public string Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        public string? Relationship { get; set; }

        [ForeignKey("Employee")]
        public int EmpSSN { get; set; }
        public Employee Employee { get; set; }
    }
}

