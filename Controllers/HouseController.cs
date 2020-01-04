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

    [HttpGet("{id}")]
    public ActionResult GetOneHouse(int id)
    {
      var db = new DatabaseContext();
      var house = db.Houses.FirstOrDefault(ho => ho.Id == id);
      if (house == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(house);
      }
    }

    [HttpPost]
    public ActionResult CreateHouse(House house)
    {
      var db = new DatabaseContext();
      db.Houses.Add(house);
      db.SaveChanges();
      return Ok(house);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateHouse(House house)
    {
      var db = new DatabaseContext();
      var prevHouse = db.Houses.FirstOrDefault(ho => ho.Id == house.Id);
      if (prevHouse == null)
      {
        return NotFound();
      }
      else
      {
        prevHouse.HouseName = house.HouseName;
        prevHouse.HouseColor = house.HouseColor;
        db.SaveChanges();
        return Ok(prevHouse);
      }
    }
  }
}