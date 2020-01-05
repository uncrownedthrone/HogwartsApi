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
      return Ok(db.StudentTables.OrderBy(student => student.FullName));
    }
    [HttpPost]
    public ActionResult CreateStudent(NewStudent vm)
    {
      var db = new DatabaseContext();
      var student = db.StudentTables.FirstOrDefault(st => st.Id == vm.StudentId);
      if (student == null)
      {
        return NotFound();
      }
      else
      {
        var list = new StudentTable
        {
          FullName = vm.FullName,
          StudentId = vm.StudentId
        };
        db.StudentTables.Add(list);
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
    public ActionResult UpdateStudent(StudentTable student)
    {
      var db = new DatabaseContext();
      var prevStudent = db.StudentTables.FirstOrDefault(st => st.Id == student.Id);
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
      var student = db.StudentTables.FirstOrDefault(st => st.Id == id);
      if (student == null)
      {
        return NotFound();
      }
      else
      {
        db.StudentTables.Remove(student);
        db.SaveChanges();
        return Ok();
      }
    }
    [HttpGet("{id}")]
    public ActionResult GetOneStudent(int id)
    {
      var db = new DatabaseContext();
      var student = db.StudentTables.Include(i => i.StudentId).FirstOrDefault(st => st.Id == id);
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