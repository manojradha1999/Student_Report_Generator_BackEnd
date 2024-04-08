using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentMarks.Model
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string SubjectName { get; set; }

        [Required]
        public int Marks { get; set; }

        [Required]
        public string Result { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
