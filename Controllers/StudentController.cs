using System.Linq;
using HogwartsApi.Models;
using HogwartsApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace StudentApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StudentController : ControllerBase
  {
    [HttpGet]
    public ActionResult GetAllStudents()
    {
      var db = new DatabaseContext();
      return Ok(db.Students.OrderBy(student => student.FullName));
    }
    [HttpPost]
    public ActionResult CreateStudent(NewStudent vm)
    {
      var db = new DatabaseContext();
      var student = db.Students.FirstOrDefault(st => st.Id == vm.StudentId);
      if (student == null)
      {
        return NotFound();
      }
      else
      {
        var list = new StudentList
        {
          FullName = vm.FullName,
          StudentId = vm.StudentId
        };
        db.Students.Add(list);
        db.SaveChanges();
        var rv = new CreatedStudent
        {
          Id = list.Id,
          FullName = list.FullName,
          StudentId = list.StudentId
        };
        return Ok(rv);
      }
    }
    [HttpPut("{id}")]
    public ActionResult UpdateStudent(StudentList student)
    {
      var db = new DatabaseContext();
      var prevStudent = db.Students.FirstOrDefault(st => st.Id == student.Id);
      if (prevStudent == null)
      {
        return NotFound();
      }
      else
      {
        prevStudent.FullName = student.FullName;
        db.SaveChanges();
        return Ok(prevStudent);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteStudent(int id)
    {
      var db = new DatabaseContext();
      var student = db.Students.FirstOrDefault(st => st.Id == id);
      if (student == null)
      {
        return NotFound();
      }
      else
      {
        db.Students.Remove(student);
        db.SaveChanges();
        return Ok();
      }
    }
    [HttpGet("{id}")]
    public ActionResult GetOneStudent(int id)
    {
      var db = new DatabaseContext();
      var student = db.Students.Include(i => i.Student).FirstOrDefault(st => st.Id == id);
      if (student == null)
      {
        return NotFound();
      }
      else
      {
        return Ok();
      }
    }

  }
}