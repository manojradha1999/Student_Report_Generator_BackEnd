namespace StudentMarks.DTO.Report
{
    public class ReportDTO
    {
        public int studentId { get; set; }
        public string studentName { get; set; }

        public int standard { get; set; }

        public int total { get; set; }

        public IEnumerable<StudentReportDTO> studentReport { get; set; }
    }
}
