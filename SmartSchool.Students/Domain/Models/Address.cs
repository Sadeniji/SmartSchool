namespace SmartSchool.Students.Domain.Models
{
    public class Address
    {
        public int Id { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
        public int StreetNumber { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
