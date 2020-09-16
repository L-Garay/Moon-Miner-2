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
  public class TestPlanetsController : ControllerBase
  {
    private readonly TestPlanetsService _tps;
    public TestPlanetsController(TestPlanetsService tps)
    {
      _tps = tps;
    }
    [HttpGet]
    public ActionResult<IEnumerable<TestPlanet>> Get()
    {
      try
      {
        return Ok(_tps.Get());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<TestPlanet> Get(int id)
    {
      try
      {
        return Ok(_tps.GetByPlanetId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<TestPlanet> Edit([FromBody] TestPlanet planet)
    {
      try
      {
        return Ok(_tps.Unlock(planet));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}