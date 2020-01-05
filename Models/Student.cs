namespace HogwartsApi.Models
{
  public class StudentList
  {
    public int Id { get; set; }
    public string FullName { get; set; }

    public int StudentId { get; set; }

    public StudentList Student { get; set; }
  }
}