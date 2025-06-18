using Exam.Dto;
using Exam.Dto.CourseDto;
using Exam.Dto.CourseInstructorDto;
using Exam.Helper;
using Exam.IRepositories;
using Exam.Models;
using Exam.Dto.CourseStudentDto;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Exam.Repository;

namespace Exam.Service.CourseService
{
    public class CourseService:ICourseService
    {
        ICourseRepository _Repo;
        ICourseInstructorRepository _courseInstructorRepository;
        IRepository<CourseInstructor> _courseInstructorRepo;
        ICourseStudentRepository _courseStudentRepository;
        IHttpContextAccessor _httpContextAccessor;
        public CourseService(ICourseRepository repo,
              ICourseInstructorRepository courseInstructorRepository,
              ICourseStudentRepository courseStudentRepository,
              IRepository<CourseInstructor> courseInstructorRepo,
        IHttpContextAccessor httpContextAccessor)
        {
            _Repo = repo;
            _courseInstructorRepository = courseInstructorRepository;
            _courseInstructorRepo = courseInstructorRepo;
            _httpContextAccessor = httpContextAccessor;
            _courseStudentRepository = courseStudentRepository;

        }
        public IQueryable<CourseDto> GetAll()
        {
              return _Repo.GetAll().MapList<CourseDto>();
        }
        public IQueryable<CourseDto> GetCourseForInstructor() {
            var httpContext = _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("httpContextNotFound");
            var instructorIdClaim = httpContext.
             User.
             FindFirst("InstructorId") ?? 
             throw new UnauthorizedAccessException("your Id notValid");
            string instructorId=instructorIdClaim.Value;
            var courseInstructorList = _courseInstructorRepository.
                   GetCoursesInstructorsForInstructor
                    (int.Parse(instructorId));

            var courseInstructorListDto = courseInstructorList.MapList<CourseInstructorDto>().ToList();
            List<CourseDto> coursesForInstructor = new List<CourseDto>();
            IQueryable<CourseDto> coursesForInstructorListDto;
            if (courseInstructorListDto.Count>0 ) { 
            foreach(var item in courseInstructorListDto)
                {
                  var course=_Repo.GetById(item.CourseId);
                    coursesForInstructor.Add(course.Mapone<CourseDto>());
                }
                coursesForInstructorListDto = coursesForInstructor.AsQueryable();
                return coursesForInstructorListDto;
            }
            else
            {
                return null;
            }

        }
        public IQueryable<CourseStudentDto> GetCourseForStudent()
        {
            var httpContext = _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("http context NotFounded");
            var user = httpContext.User.FindFirst("StudentId") ?? throw new InvalidOperationException("you have not valid Id ");
            string studentId = user.Value;
             List<CourseStudentDto> courses =new List<CourseStudentDto>();

            IQueryable<CourseStudentDto> courseStudentListDto = _courseStudentRepository.GetCoursesForStudent(int.Parse(studentId)).MapList<CourseStudentDto>();
            if (courseStudentListDto.LongCount() > 0)
            {
                foreach(var item in courseStudentListDto.ToList())
                {
                    var course = _Repo.GetById(item.CourseId);
                    if (course != null)
                    {
                      var courseStudentDto=  new CourseStudentDto()
                        {
                            CourseId = item.CourseId,
                            StudentDegree = item.StudentDegree,
                            Description = course.Description,
                            Name = course.Name,
                            Hours = course.Hours,
                        };
                        courses.Add(courseStudentDto);
                    }

                }
                return courses.AsQueryable();
            }
            return courseStudentListDto;
        
        
        
        
        
        
        }

        public CourseDto GetById(int id)
        {
            return _Repo.GetById(id).Mapone<CourseDto>();
        }

        public  CourseDto Add(CourseDto entitydto)
        {
            var entity =entitydto.Mapone<Course>();
            var Course= _Repo.Add(entity); 
            _Repo.SaveChanges();
            var courseEditDto=entity.Mapone<CourseEditDto>();
            var httpcontext = _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("httpcontext not founded");
            string instructorId = httpcontext.User.FindFirstValue("InstructorId");
            var courseInstructor = new CourseInstructor()
            {
                CourseId = courseEditDto.Id,
                InstructorId = int.Parse(instructorId),
            };
            _courseInstructorRepo.Add(courseInstructor);
            _courseInstructorRepo.SaveChanges();
            return courseEditDto.Mapone<CourseDto>();   


        }

        public CourseDto Update(CourseEditDto editdtoentity)
        {
            var entity =editdtoentity.Mapone<Course>();
            return _Repo.Update(entity).Mapone<CourseDto>();
        }

        public CourseDto DeleteById(int id)
        {
            return _Repo.DeleteById(id).Mapone<CourseDto>();    
        }
       

    }
}
