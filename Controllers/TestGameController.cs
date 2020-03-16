using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using moonminer.Models;
using moonminer.Services;

namespace moonminer.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TestGameController : ControllerBase
  {
    private readonly TestGamesService _tgs;
    public TestGameController(TestGamesService tgs)
    {
      _tgs = tgs;
    }
    [HttpPost]
    public ActionResult<TestGame> Post([FromBody] TestGame newGame)
    {
      try
      {
        return Ok(_tgs.Create(newGame));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet]
    public ActionResult<IEnumerable<TestGame>> GetAction()
    {
      try
      {
        return Ok(_tgs.Get());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}
