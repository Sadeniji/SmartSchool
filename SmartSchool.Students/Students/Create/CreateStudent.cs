using MediatR;
using SmartSchool.Students.Data.Migrations;
using SmartSchool.Students.Domain.Models;

namespace SmartSchool.Students.Students.Create
{
    public record CreateStudent(NewStudent NewStudent) : IRequest<StudentBasicInfo>;

    public class CreateStudentHandler(AppDbContext context) : IRequestHandler<CreateStudent, StudentBasicInfo>
    {
        public async Task<StudentBasicInfo> Handle(CreateStudent request, CancellationToken cancellationToken)
        {
            var student = Student.Create(request.NewStudent.RollNumber, request.NewStudent.FirstName,
                                         request.NewStudent.LastName, request.NewStudent.DateOfBirth,
                                         request.NewStudent.Gender);

            context.Students.Add(student);
            await context.SaveChangesAsync(cancellationToken);

            return StudentBasicInfo.FromStudent(student);
        }
    }
}
