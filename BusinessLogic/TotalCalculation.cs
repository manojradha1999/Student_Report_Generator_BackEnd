using StudentMarks.DTO.Report;

namespace StudentMarks.BusinessLogic
{
    public class TotalCalculation
    {

        // For calculating the total marks.
        public static int TotalMarks(List<StudentReportDTO> student)
        {
            int total = 0;
            foreach(StudentReportDTO std in student)
            {
                total += std.Mark;
            }
            return total;
        }
    }
}
