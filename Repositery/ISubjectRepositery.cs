using StudentMarks.DTO.Student;
using StudentMarks.DTO.Subject;
using StudentMarks.Model;

namespace StudentMarks.Repositery
{
    public interface ISubjectRepositery
    {
        Task<List<Subject>> GetAll();
        Task<Subject> Get(int id);
        Task Create(Subject student);
        Task<int> Update(Subject student);
        Task<bool> CreateCheck(CreateSubjectDTO studentDTO);
        Task<bool> UpdateCheck(UpdateSubjectDTO studentDTO);
        Task Save();
    }
}
