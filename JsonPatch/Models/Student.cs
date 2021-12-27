using System;

namespace JsonPatch.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public DateTime StartDate { get; set; }
        public string FieldOfStudy { get; set; }
    }
}
