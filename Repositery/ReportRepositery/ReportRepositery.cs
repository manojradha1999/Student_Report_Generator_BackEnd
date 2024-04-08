using Microsoft.EntityFrameworkCore;
using StudentMarks.BusinessLogic;
using StudentMarks.Context;
using StudentMarks.DTO.Report;
using StudentMarks.Model;

namespace StudentMarks.Repositery.ReportRepositery
{
    public class ReportRepositery : IReportRepositery
    {
        private readonly StudentDbContext _studentDbContext;
        public ReportRepositery(StudentDbContext studentDbContext) {
            _studentDbContext = studentDbContext;
        }

        // Gets the subjects details of given student.
        public async Task<ReportDTO> GetReport(int standard, string name)
        {
            var result = await (from std in _studentDbContext.students
             join sub in _studentDbContext.subjects on std.StudentId equals sub.StudentId
             where std.standard.Equals( standard)  && std.StudentName.Equals(name)
             select new StudentReportDTO
             {
                 StudentId = sub.StudentId,
                 SubjectName = sub.SubjectName,
                 Mark = sub.Marks,
                 Result = sub.Result
             }).ToListAsync();

            if (result.Count > 0)
            {
                var stud = result.ElementAt(0);
                var report = new ReportDTO();
                report.studentId = stud.StudentId;
                var details = await GetStudent(stud.StudentId);
                report.studentName = details.StudentName;
                report.standard = details.standard;
                report.studentReport = result;
                report.total = TotalCalculation.TotalMarks(result);

                return report;
            }

            return null;
        }

        // Gets the details of the given student.
        public async Task<Student> GetStudent(int id)
        {
            var result = await (from std in _studentDbContext.students
                          where std.StudentId == id
                          select std).FirstOrDefaultAsync();
            if( result == null)
            {
                return null;
            }
            return result;
        }

    }
}
