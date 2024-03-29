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
    internal string ResetPlanets()
    {
      _repo.ResetPlanets();
      return "Successfully reset..";
    }
  }
}