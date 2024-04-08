namespace StudentMarks.DTO.Subject
{
    public class UpdateSubjectDTO
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int Marks { get; set; }

        public int StudentId { get; set; }
    }
}
