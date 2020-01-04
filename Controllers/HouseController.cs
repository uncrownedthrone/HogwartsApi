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
  }
}