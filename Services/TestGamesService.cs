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

    internal TestGame GetCreatedGame()
    {
      return _repo.GetCreatedGame();
    }
    internal IEnumerable<TestGame> GetSavedGames()
    {
      return _repo.GetSavedGames();
    }
  }
}