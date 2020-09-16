using System;
using System.Collections.Generic;
using System.Data;
using moonminer.Models;
using moonminer.Repositories;

namespace moonminer.Services
{
  public class TestPlanetsService
  {
    private readonly TestPlanetsRepository _repo;
    public TestPlanetsService(TestPlanetsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<TestPlanet> Get()
    {
      return _repo.Get();
    }
    internal TestPlanet GetByPlanetId(int id)
    {
      return _repo.GetById(id);
    }
    internal TestPlanet Unlock(TestPlanet planet)
    {
      var exists = _repo.GetById(planet.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      else
      {
        var updatedPlanet = planet;
        updatedPlanet.isLocked = false;
        _repo.Unlock(updatedPlanet);
        return updatedPlanet;
      }
    }
    // NOTE this is the exact same function but the one above is manually called by the player whenever they hit the 'Unlock Planet' Button.  Where the one below is called automatically everytime the planet compoenent is loaded, to check to is the current planet is locked or not (for when a user returns to the game after the planets have been reset)
    internal TestPlanet EditLocked(TestPlanet planet)
    {
      var exists = _repo.GetById(planet.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      else
      {
        var updatedPlanet = planet;
        updatedPlanet.isLocked = false;
        _repo.Unlock(updatedPlanet);
        return updatedPlanet;
      }
    }
  }
}