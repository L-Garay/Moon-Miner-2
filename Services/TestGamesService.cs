using System;
using System.Collections.Generic;
using System.Data;
using moonminer.Models;
using moonminer.Repositories;

namespace moonminer.Services
{
  public class TestGamesService
  {
    private readonly TestGamesRepository _repo;
    public TestGamesService(TestGamesRepository repo)
    {
      _repo = repo;
    }

    internal TestGame Create(TestGame newGame)
    {
      _repo.Create(newGame);
      return newGame;
    }

    internal TestGame GetGame(int id)
    {
      return _repo.GetGame(id);
    }
    internal IEnumerable<TestGame> GetSavedGames()
    {
      return _repo.GetSavedGames();
    }
    internal TestGame Purchase(TestGame update)
    {
      var exists = _repo.GetGame(update.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      else
      {
        _repo.Purchase(update);
        return update;
      }
    }
  }
}