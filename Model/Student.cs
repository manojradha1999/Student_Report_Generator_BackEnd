using System.ComponentModel.DataAnnotations;

namespace StudentMarks.Model
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string StudentName { get; set; }

        [Required]
        public int standard { get; set; }
    }
}
