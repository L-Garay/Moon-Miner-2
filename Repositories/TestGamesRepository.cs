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

    internal TestGame GetGame(int id)
    {
      string sql = "SELECT * FROM testgame WHERE id = @id;";
      return _db.QueryFirstOrDefault<TestGame>(sql);
    }
    internal IEnumerable<TestGame> GetSavedGames()
    {
      string sql = "SELECT * FROM testgame;";
      return _db.Query<TestGame>(sql);
    }
  }
}