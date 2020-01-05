using System.Linq;
using HogwartsApi.Models;
using HogwartsApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
      var house = db.Houses.Include(i => i.StudentTables).FirstOrDefault(ho => ho.Id == id);
      if (house == null)
      {
        return NotFound();
      }
      else
      {
        // var rv = new HouseDetails
        // {
        //   Id = house.Id,
        //   HouseName = house.HouseName,
        //   HouseColor = house.HouseColor,
        //   StudentLists = house.StudentLists.Select(ns => new CreatedStudent
        //   {
        //     FullName = ns.FullName,
        //     StudentId = ns.StudentId,
        //     Id = ns.Id
        //   }).ToList()
        // };
        return Ok();
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
    [HttpDelete]
    public ActionResult DeleteHouse(int id)
    {
      var db = new DatabaseContext();
      var house = db.Houses.FirstOrDefault(ho => ho.Id == id);
      if (house == null)
      {
        return NotFound();
      }
      else
      {
        db.Houses.Remove(house);
        db.SaveChanges();
        return Ok();
      }
    }
  }
}