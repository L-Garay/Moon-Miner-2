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
    [HttpGet("{id}")]
    public ActionResult<TestGame> GetGame(int id)
    {
      try
      {
        return Ok(_tgs.GetGame(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("all")]
    public ActionResult<IEnumerable<TestGame>> GetSavedGames()
    {
      try
      {
        return Ok(_tgs.GetSavedGames());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<TestGame> Update([FromBody] TestGame update)
    {
      try
      {
        return Ok(_tgs.Update(update));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<String> DeleteGame(int id)
    {
      try
      {
        return Ok(_tgs.DeleteGame(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
