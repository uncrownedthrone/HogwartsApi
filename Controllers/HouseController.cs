using System.Linq;
using HogwartsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HouseController : ControllerBase
  {
    [HttpGet]
    public ActionResult GetAllHouses()
    {
      var db = new DatabaseContext();
      return Ok(db.Houses.OrderBy(house => house.HouseName));
    }
    [HttpPost]
    public ActionResult CreateHouse(House house)
    {
      var db = new DatabaseContext();
      db.Houses.Add(house);
      db.SaveChanges();
      return Ok(house);
    }
  }
}