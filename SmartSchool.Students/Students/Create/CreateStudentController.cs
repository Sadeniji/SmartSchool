using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.Students.Domain.Models;

namespace SmartSchool.Students.Students.Create
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateStudentController : StudentBaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(StudentBasicInfo), 200)]
        public async Task<IActionResult> CreateStudent([FromBody] NewStudent newStudent, CancellationToken cancellationToken)
        {
            var command = new CreateStudent(newStudent);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }

    public record NewStudent(string RollNumber, string FirstName, string LastName, DateTime DateOfBirth, Gender Gender);
}
