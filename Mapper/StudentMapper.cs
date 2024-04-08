using AutoMapper;
using StudentMarks.DTO.Student;
using StudentMarks.DTO.Subject;
using StudentMarks.Model;

namespace StudentMarks.Mapper
{
    public class StudentMapper: Profile
    {
        public StudentMapper() {

            // Mapping the DTO with models.
            CreateMap<CreateStudentDTO, Student>().ReverseMap();
            CreateMap<StudentDTO, Student>().ReverseMap();
            CreateMap<CreateSubjectDTO, Subject>().ReverseMap();
            CreateMap<UpdateSubjectDTO, Subject>().ReverseMap();
            CreateMap<GetSubjectDTO, Subject>().ReverseMap();
        }
    }
}
