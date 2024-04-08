using System.ComponentModel.DataAnnotations;

namespace StudentMarks.DTO.Student
{
    public class CreateStudentDTO
    {
        public string StudentName { get; set; }

        public int standard { get; set; }
    }
}
