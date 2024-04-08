using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentMarks.Context;
using StudentMarks.DTO.Student;
using StudentMarks.Mapper;
using StudentMarks.Model;

namespace StudentMarks.Repositery.StudentRepositery
{
    public class StudentRepositery : IStudentRepositery
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentRepositery(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        // Common save method.
        public async Task Save()
        {
            await _studentDbContext.SaveChangesAsync();
        }

        // Get all Student details.
        public async Task<List<Student>> GetAll()
        {
            var stds = await (from stud in _studentDbContext.students
                        select stud).ToListAsync();
            return stds;
        }

        // Get the details of given student.
        public async Task<Student> Get(int id)
        {
            var std = await (from stud in _studentDbContext.students
                       where stud.StudentId.Equals(id)
                       select stud).FirstOrDefaultAsync();
            return std;
        }

        // Create the student.
        public async Task<Student> Create(Student student)
        {
            await _studentDbContext.students.AddAsync(student);
            await Save();

            return student;
        }

        // Condition check for create student.
        public async Task<bool> CreateCheck(CreateStudentDTO studentDTO)
        {
            var std = await (from stud in _studentDbContext.students
                       where stud.StudentName.Equals(studentDTO.StudentName)
                       && stud.standard.Equals(studentDTO.standard)
                       select stud).FirstOrDefaultAsync();
            if(std != null)
            {
                return true;
            }
            return false;
        }

        // Condition check for update student.
        public async Task<bool> UpdateCheck(StudentDTO studentDTO)
        {
            var std = await (from stud in _studentDbContext.students
                       where stud.StudentId.Equals(studentDTO.StudentId)
                       select stud).FirstOrDefaultAsync();
            if(std != null)
            {
                return true;
            }
            return false;
        }

        // Update the student details.
        public async Task<int> Update(Student student)
        {
            var result = await _studentDbContext.Database.ExecuteSqlRawAsync($"UpdateStudent {student.StudentName}, {student.standard},{student.StudentId}");
            await Save();
            return result;
        }
    }
}
