using JsonPatch.Extensions;
using JsonPatch.Models;
using JsonPatch.Models.Patch;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonPatch.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private List<Student> _students = new List<Student> {
			new Student { Email = "johndoe@gmail.com", Id = 1,Name = "John Doe"},
			new Student { Email = "johndoe2@gmail.com", Id = 2,Name = "John Doe2"},
			new Student { Email = "johndoe3@gmail.com", Id = 3,Name = "John Doe3"}
		};

		[HttpPatch("{id}")]
		public async Task<dynamic> PatchAsync(string id, JsonPatchDocument<PatchStudent> jsonPatchDocument)
		{
			var student = default(Student);

			// get the entity from the DB
			if (_students.Any(x => x.Id.ToString() == id))
            {
				student = _students.First(x => x.Id.ToString() == id);
            }
            else
            {
				throw new NullReferenceException("Invalid record!");
            }

			// update it via the Path .ApplyTo()
			jsonPatchDocument.Map<PatchStudent, Student>().ApplyTo(student);

			// update the DB

			// return
			return _students;
		}

		[HttpGet]
		public async Task<List<Student>> GetAsync()
		{
			return _students;
		}
	}
}
