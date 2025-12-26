using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage ="Name is a required field")]
        [StringLength(255,ErrorMessage ="String length should not exceed 255")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string Name { get; set; }

        public int DepartmentID { get; set; }
    }
}
