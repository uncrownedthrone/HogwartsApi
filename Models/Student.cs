namespace HogwartsApi.Models
{
  public class StudentTable
  {
    public int Id { get; set; }
    public string FullName { get; set; }

    public int StudentId { get; set; }

    public House House { get; set; }
  }
}