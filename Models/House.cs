using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HogwartsApi.Models
{
  public class House
  {
    public int Id { get; set; }
    public string HouseName { get; set; }
    public string HouseColor { get; set; }

    public List<StudentTable> StudentTables { get; set; }
       = new List<StudentTable>();
  }
}