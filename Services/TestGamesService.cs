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
    internal TestGame Update(TestGame update)
    {
      var exists = _repo.GetGame(update.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      else
      {
        _repo.Update(update);
        return update;
      }
    }
    internal string DeleteGame(int id)
    {
      var exists = _repo.GetGame(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.DeleteGame(id);
      return "Successfully deleted..";
    }
  }
}