
using AutoMapper;
using Exam.Dto.RoleFeatureDto;
using Exam.Helper;
using Exam.IRepositories;
using Exam.Mediator.ExamQuestion;
using Exam.Mediator.InstructorUser;
using Exam.Models;
using Exam.Profile;
using Exam.Repository;
using Exam.Service;
using Exam.Service.ChoicesService;
using Exam.Service.InstructorService;
using Exam.Service.QuestionChoiceService;
using Exam.Service.RoleFeatureService;
using Exam.Service.RoleService;
using Exam.Service.UserService;
using Exam.MiddleWare;


using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Exam.Service.StudentService;
using Exam.Mediator.StudentUser;
using Exam.Service.CourseService;
using Exam.Filters;
using Exam.Service.CourseInstructorService;

namespace Exam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            // Add services to the container.

            builder.Services.AddControllers();
         
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

                // Add JWT Authentication support in Swagger
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lowercase
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference { Id = "bearer",
                        Type = ReferenceType.SecurityScheme }

                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    });
            });
            builder.Services.AddAutoMapper(typeof(ExamProfile));
            builder.Services.AddDbContext<ExamContext>(options =>
            options.
            UseSqlServer(builder.
            Configuration.
            GetConnectionString("ExamDb")));
            builder.Services.AddScoped  <DbContext,ExamContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IService<,,>), typeof(Service<,,>));
            builder.Services.AddScoped<IQuestionService, QuestionService > ();
            builder.Services.AddScoped<IExamQuestionMediator, ExamQuestionMediator>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleFeatureService, RoleFeatureService>();
            builder.Services.AddScoped<IRoleFeatureRopository, RoleFeatureRepository >();
            builder.Services.AddScoped<IRoleService, RoleService2>();
            builder.Services.AddScoped<IChoiceService, ChoiceService>();
            builder.Services.AddScoped<IInstructorService, InstructorService>();
            builder.Services.AddScoped<IInstructorUserMediator, InstructorUserMediator>();
            builder.Services.AddScoped<IStudentServise,StudentService>();
            builder.Services.AddScoped<IStudentUserMediator, StudentUserMediator>();
            builder.Services.AddScoped<ICourseService,CourseService>();
            builder.Services.AddScoped<ICourseInstructorRepository,CourseInstructorRepository>();
            builder.Services.AddScoped<ICourseRepository,CourseRepository>();
            builder.Services.AddScoped<ICourseStudentRepository, CourseStudentRepository>();

            builder.Services.AddHttpContextAccessor();





            // authentication
            builder.Services.AddAuthentication(
                op => op.DefaultAuthenticateScheme = "bearer").
                AddJwtBearer("bearer", option =>
                {
                    string key =
  "masr gamila geda 5als ya 7omsany kan m3kmwaled beeh abooelnasr 5alek faker ya ebny tamtam tamam tamam trump";

                    var secretkey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(key));
                    option.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        IssuerSigningKey = secretkey,
                        ValidateAudience = false,
                        ValidateIssuer=false,
                        
                    };
                }


                );
            builder.Services.AddHttpContextAccessor();




            var app = builder.Build();
            MapperHelper._mapper = app.Services.GetService<IMapper>();
            app.UseMiddleware<TransactionMiddleWare>();
            app.UseMiddleware<GlobalErrorHandling>();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); // Must come before UseAuthorization
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
