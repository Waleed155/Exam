using AutoMapper;
using Exam.Dto;
using Exam.Dto.CourseDto;
using Exam.Dto.ExamDto;
using Exam.Dto.ExamQuestionDto;
using Exam.Dto.QuestionChoiceDto;
using Exam.Dto.QuestionDto;
using Exam.Dto.RoleDto;
using Exam.Dto.RoleFeatureDto;
using Exam.Dto.StudentDto;
using Exam.Dto.UserDto;
using Exam.Models;
using Exam.ViewModels.ChoiceViewModel;
using Exam.ViewModels.CourseViewModel;
using Exam.ViewModels.ExamQuestionViewmodel;
using Exam.ViewModels.ExamViewModel.ExamViewModel;
using Exam.ViewModels.InstructorViewModel;
using Exam.ViewModels.QuestionChoiceViewModel;
using Exam.ViewModels.QuestionViewModel;
using Exam.ViewModels.RoleFeatureViewModel;
using Exam.ViewModels.RoleViewModel;
using Exam.ViewModels.StudentViewModel;
using Exam.ViewModels.UserViewModel;
using Exam.ViewModels.InstructorUserViewMdel;
using Exam.ViewModels.StudentUserViewModel;
using Exam.Dto.StudentUserDto;
using Exam.Dto.CourseInstructorDto;
using Exam.Dto.CourseStudentDto;
using Exam.ViewModels.CourseStudentViewModel;



namespace Exam.Profile
{
    public class ExamProfile:AutoMapper.Profile
    {
        public ExamProfile() {
            
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserEditDto>().ReverseMap();
            CreateMap<UserDto, UserEditDto>().ReverseMap();

            CreateMap<UserViewModel, UserDto>().ReverseMap();
            CreateMap<UserEditViewModel, UserEditDto>().ReverseMap();
            CreateMap<GetUserDto, GetUserViewModel>().ReverseMap();
            CreateMap<GetUserDto, User>().ReverseMap();
            CreateMap<GetUserDto, UserDto>().ReverseMap();

            CreateMap<InstructorUserViewModel, UserDto>().ReverseMap();
         













            CreateMap<Models.Exam,Dto.ExamDto.ExamDto>().ReverseMap();
            CreateMap<Models.Exam, Dto.ExamDto.ExamEditDto>().ReverseMap();
            CreateMap<ExamViewModel, Dto.ExamDto.ExamDto>().ReverseMap();
            CreateMap<ExamEditViewModel, Dto.ExamDto.ExamEditDto>().ReverseMap();
            CreateMap<ExamEditViewModel, ExamViewModel>().ReverseMap();

            CreateMap<ExamQuestionDto, QuestionDto>().ReverseMap();
            CreateMap<ExamQuestionDto, QuestionChoiceDto>().ReverseMap();
            CreateMap<ExamQuestionDto, ExamQuestionViewModel>().ReverseMap();
            CreateMap<ExamQuestionAddDto, ExamQuestion>().ReverseMap();






            CreateMap<Choice,ChoiceDto>().ReverseMap();
            CreateMap<ChoiceEditDto,Choice>().ReverseMap();
            CreateMap<ChoiceEditDto, ChoiceDto>().ReverseMap();
            CreateMap<ChoiceViewModel, ChoiceDto>().ReverseMap();
            CreateMap<ChoiceEditViewModel, ChoiceEditDto>().ReverseMap();
            CreateMap<ChoiceEditViewModel, ChoiceViewModel>().ReverseMap();




            CreateMap<InstructorEditDto, InstructorDto>().ReverseMap();
            CreateMap<InstructorDto, Instructor>().ReverseMap();
            CreateMap<InstructorEditDto, Instructor>().ReverseMap();
            CreateMap<Instructor,InstructorDto>().ReverseMap();
            CreateMap<Instructor, InstructorEditDto>().ReverseMap();
            CreateMap<InstructorEditDto, InstructorDto>().ReverseMap();
            CreateMap<InstructorViewModel, InstructorDto>().ReverseMap();
            CreateMap<InstructorEditViewModel, InstructorEditDto>().ReverseMap();
            CreateMap<InstructorEditViewModel,InstructorViewModel>().ReverseMap();
            CreateMap<InstructorUserViewModel, InstructorDto>().ForMember
         (dest => dest.Name, opt => opt.MapFrom(src => src.UserName));






            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Question, QuestionEditDto>().ReverseMap();
            CreateMap<QuestionEditDto, QuestionDto>().ReverseMap();
            CreateMap<QuestionViewModel, QuestionDto>().ReverseMap();
            CreateMap<QuestionEditViewModel, QuestionEditDto>().ReverseMap();
            CreateMap<QuestionEditViewModel, QuestionViewModel>().ReverseMap();


            CreateMap<Student, StudentEditDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<StudentDto, StudentEditDto>().ReverseMap();
            CreateMap<StudentEditViewModel, StudentEditDto>().ReverseMap();
            CreateMap<StudentViewModel, StudentDto>().ReverseMap();
            CreateMap<StudentViewModel, StudentEditViewModel>().ReverseMap();




            CreateMap<StudentUserDto, StudentDto>().
                ForMember(dis => dis.Name, op => op.MapFrom(src => src.UserName));
            CreateMap<StudentUserDto, UserDto>().ReverseMap();
            CreateMap<StudentUserDto, StudentUserViewModel>().ReverseMap();






            CreateMap<Course, CourseEditDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<CourseDto, CourseEditDto>().ReverseMap();
            CreateMap<CourseEditViewModel, CourseEditDto>().ReverseMap();
            CreateMap<CourseViewModel, CourseDto>().ReverseMap();
            CreateMap<CourseViewModel, CourseEditViewModel>().ReverseMap();
            CreateMap<CourseInstructor,CourseInstructorDto>().ReverseMap();
            CreateMap<CourseStudentDto, Course>().ReverseMap();
            CreateMap<CourseStudentDto, StudentCourse>().ReverseMap();
            CreateMap<CourseStudentDto, CourseStudentViewModel>().ReverseMap();







            CreateMap<QuestionChoice, QuestionChoiceAddDto>().ReverseMap();
            CreateMap<QuestionChoiceEDitDto, QuestionChoice>().ReverseMap();
            CreateMap<QuestionChoiceEDitDto, QuestionChoiceAddDto>().ReverseMap();
            CreateMap<QuestionChoiceViewModel, QuestionChoiceDto>().ReverseMap();




            CreateMap<AuthorizeRole, RoleDto>().ReverseMap();
            CreateMap<RoleEditDto, AuthorizeRole>().ReverseMap();
            CreateMap<RoleDto, RoleEditDto>().ReverseMap();
            CreateMap<RoleEditViewModel, RoleEditDto>().ReverseMap();
            CreateMap<RoleViewModel, RoleDto>().ReverseMap();





            CreateMap<RoleFeatureDto, RoleFeature>().ReverseMap();
            CreateMap<RoleFeatureEditDto, RoleFeature>().ReverseMap();
            CreateMap<RoleFeatureEditDto, RoleFeatureDto>().ReverseMap();
            CreateMap<RoleFeatureDto, RoleFeatureViewModel>().ReverseMap();
            CreateMap<RoleFeatureEditViewModel, RoleFeatureEditDto>().ReverseMap();
            CreateMap<RoleFeatureEditViewModel, RoleFeatureEditDto>().ReverseMap();











        }
    }
}
