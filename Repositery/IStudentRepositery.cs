using StudentMarks.DTO.Student;
using StudentMarks.Model;

namespace StudentMarks.Repositery
{
    public interface IStudentRepositery
    {
        Task<List<Student>> GetAll();
        Task<Student> Get(int id);
        Task<Student> Create(Student student);
        Task<int> Update(Student student);
        Task<bool> CreateCheck(CreateStudentDTO studentDTO);
        Task<bool> UpdateCheck(StudentDTO studentDTO);
        Task Save();
    }
}
