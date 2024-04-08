using System.ComponentModel.DataAnnotations;

namespace StudentMarks.DTO.Student
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int standard { get; set; }
    }
}
