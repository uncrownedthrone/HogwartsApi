using System.Collections.Generic;

namespace HogwartsApi.Models
{
  public class HouseDetails
  {
    public int Id { get; set; }
    public string HouseName { get; set; }
    public string HouseColor { get; set; }

    public List<StudentTable> Students { get; set; }
       = new List<StudentTable>();
  }
}