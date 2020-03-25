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
  }
}