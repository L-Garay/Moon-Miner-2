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
      string sql = @"INSERT INTO testing (plalyerName, profileImg, playerMoney) VALUES (@PlayerName, @ProfileImg, @PlayerMoney); SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newGame);
      newGame.Id = id;
      return newGame;
    }
  }
}