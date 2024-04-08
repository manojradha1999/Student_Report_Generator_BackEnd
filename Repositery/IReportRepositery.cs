using StudentMarks.DTO.Report;
using StudentMarks.Model;

namespace StudentMarks.Repositery
{
    public interface IReportRepositery
    {
        Task<ReportDTO> GetReport(int id, string name);

        //Task<Student> GetStudent(int id);

    }
}
