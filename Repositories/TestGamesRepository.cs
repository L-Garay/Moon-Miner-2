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
      return _db.QueryFirstOrDefault<TestGame>(sql, new { id });
    }
    internal IEnumerable<TestGame> GetSavedGames()
    {
      string sql = "SELECT * FROM testgame;";
      return _db.Query<TestGame>(sql);
    }
    internal void Update(TestGame update)
    {
      string sql = @"UPDATE testgame SET playerName = @PlayerName, profileImg = @ProfileImg, playerEnergy = @PlayerEnergy, playerTool = @PlayerTool, playerMoney = @PlayerMoney, resource1 = @Resource1, resource2 = @Resource2, resource3 = @Resource3, resource4 = @Resource4 WHERE id = @Id;";
      _db.Execute(sql, update);
    }
    internal void DeleteGame(int id)
    {
      string sql = "DELETE FROM testgame WHERE id = @id;";
      _db.Execute(sql, new { id });
    }
  }
}