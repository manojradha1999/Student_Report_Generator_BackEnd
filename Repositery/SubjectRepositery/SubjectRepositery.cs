using Microsoft.EntityFrameworkCore;
using StudentMarks.Context;
using StudentMarks.DTO.Student;
using StudentMarks.DTO.Subject;
using StudentMarks.Model;

namespace StudentMarks.Repositery.SubjectRepositery
{
    public class SubjectRepositery : ISubjectRepositery
    {
        private readonly StudentDbContext _studentDbContext;
        public SubjectRepositery(StudentDbContext studentDbContext) {
            _studentDbContext = studentDbContext;
        }

        public async Task Save()
        {
            await _studentDbContext.SaveChangesAsync();
        }

        // Get subjects details.
        public async Task<List<Subject>> GetAll()
        {
            var stds = await (from stud in _studentDbContext.subjects
                              select stud).ToListAsync();
            return stds;
        }

        // Get the given subject details.
        public async Task<Subject> Get(int id)
        {
            var std = await (from stud in _studentDbContext.subjects
                       where stud.SubjectId.Equals(id)
                       select stud).FirstOrDefaultAsync();
            if(std != null ) {
                return std;
            }

            return null;
        }

        // Create the subject.
        public async Task Create(Subject subject)
        {
            await _studentDbContext.subjects.AddAsync(subject);
            await Save();
        }

        // Create condition check for the subject details.
        public async Task<bool> CreateCheck(CreateSubjectDTO createSubjectDTO)
        {
            var std = await (from stud in _studentDbContext.students
                             where stud.StudentId.Equals(createSubjectDTO.StudentId)
                             select stud).FirstOrDefaultAsync();
            var sub = await (from subj in _studentDbContext.subjects
                       where subj.SubjectName.Equals(createSubjectDTO.SubjectName) &&
                       subj.StudentId.Equals(createSubjectDTO.StudentId)
                       select subj).FirstOrDefaultAsync();
            if (std != null && sub == null)
            {
                return true;
            }
            return false;
        }

        // Update Condition check for subject.
        public async Task<bool> UpdateCheck(UpdateSubjectDTO updateSubjectDTO)
        {
            var std = await (from sub in _studentDbContext.subjects
                       where sub.SubjectId.Equals(updateSubjectDTO.SubjectId)
                       select sub).FirstOrDefaultAsync();
            if (std != null)
            {
                return true;
            }
            return false;
        }

        // Update the subject details.
        public async Task<int> Update(Subject subject)
        {
            var result = await _studentDbContext.Database.ExecuteSqlRawAsync($"UpdateSubjectDetails " +
                    $"{subject.SubjectName}, {subject.Marks},{subject.StudentId},{subject.Result},{subject.SubjectId}");
            await Save();

            return result;
        }


    }
}
