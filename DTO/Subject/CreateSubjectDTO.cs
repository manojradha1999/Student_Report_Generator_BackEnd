using System.ComponentModel.DataAnnotations;

namespace StudentMarks.DTO.Subject
{
    public class CreateSubjectDTO
    {
        public string SubjectName { get; set; }

        public int Marks { get; set; }

        public int StudentId { get; set; }
    }
}
