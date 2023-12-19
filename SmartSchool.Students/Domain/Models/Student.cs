namespace SmartSchool.Students.Domain.Models
{
    public class Student
    {
        #region Constructors and Properties
        public Student()
        {
            Relatives = new List<Relative>();
        }
        public int Id { get; set; }
        public Gender Gender { get; set; }
        public required string RollNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => CalculateAge();
        public string? PhoneNumber { get; set; }
        public Address? Address { get; set; }
        public ICollection<Relative> Relatives { get; set; }
        #endregion

        #region Public Behaviour
        public static Student Create(string rollNumber, string firstName, string lastName, DateTime dateOfBirth, Gender gender)
        {
            return new Student
            {
                RollNumber = rollNumber,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Gender = gender
            };
        }
        private int CalculateAge()
        {
            var currentDate = DateTime.UtcNow;
            var age = currentDate.Year - DateOfBirth.Year;

            if (currentDate.Month < DateOfBirth.Month ||
                (currentDate.Month == DateOfBirth.Month && currentDate.Day < DateOfBirth.Day))
            {
                age--;
            }
            return age;
        }
        #endregion
    }
}
