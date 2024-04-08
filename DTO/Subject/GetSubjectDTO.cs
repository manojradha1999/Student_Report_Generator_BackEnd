using System.ComponentModel.DataAnnotations;

namespace StudentMarks.DTO.Subject
{
    public class GetSubjectDTO
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public int Marks { get; set; }

        public string Result { get; set; }

        public int StudentId { get; set; }
    }
}
