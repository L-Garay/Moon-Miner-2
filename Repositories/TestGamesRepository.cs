using System;
using System.Collections.Generic;
using System.Data;
using moonminer.Models;
using Dapper;

namespace moonminer.Repositories
{
  public class TestGamesRepository
  {
    private readonly IDbConnection _db;

    public TestGamesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal TestGame Create(TestGame newGame)
    {
      string sql = @"INSERT INTO testgame (playerName, profileImg) VALUES (@PlayerName, @ProfileImg); SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newGame);
      newGame.Id = id;
      return newGame;
    }

    internal TestGame Get()
    {
      string sql = "SELECT * FROM testgame ORDER BY id DESC LIMIT 1;";
      return _db.QueryFirstOrDefault<TestGame>(sql);
    }
  }
}