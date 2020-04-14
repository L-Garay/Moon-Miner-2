using System;
using System.Collections.Generic;
using System.Data;
using moonminer.Models;
using Dapper;

namespace moonminer.Repositories
{
  public class TestPlanetsRepository
  {
    private readonly IDbConnection _db;

    public TestPlanetsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<TestPlanet> Get()
    {
      string sql = "SELECT * FROM testplanets;";
      return _db.Query<TestPlanet>(sql);
    }
    internal TestPlanet GetById(int id)
    {
      string sql = "SELECT * FROM testplanets WHERE id = @id;";
      return _db.QueryFirstOrDefault<TestPlanet>(sql, new { id });
    }
    internal void Unlock(TestPlanet planet)
    {
      string sql = @"UPDATE testplanets SET planetName = @PlanetName, moneyNeeded = @MoneyNeeded, expiditionCost = @ExpiditionCost, resource1 = @Resource1, resource2 = @Resource2, resource3 = @Resource3, resource4 = @Resource4, planetImg = @planetImg, isLocked = @isLocked WHERE id = @Id;";
      _db.Execute(sql, planet);
    }
  }
}