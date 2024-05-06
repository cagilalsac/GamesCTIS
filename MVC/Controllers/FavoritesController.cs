﻿using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private const string _SESSIONKEY = "favoritessessionkey";

        private readonly IGameService _gameService;

        public FavoritesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            var favorites = GetSession();
            return View(favorites);
        }

        public IActionResult Add(int gameId)
        {
            var favorites = GetSession();
            var game = _gameService.GetItem(gameId);
            var favorite = new FavoriteModel()
            {
                GameId = game.Id,
                GameName = game.Name,
                TotalSalesPrice = game.TotalSalesPrice,
                TotalSalesPriceOutput = game.TotalSalesPriceOutput,
                UserName = User.Identity.Name
            };
            favorites.Add(favorite);
            SetSession(favorites);
            return RedirectToAction("Index", "Games");
        }

        private List<FavoriteModel> GetSession()
        {
            var favorites = new List<FavoriteModel>();
            var json = HttpContext.Session.GetString(_SESSIONKEY);
            if (!string.IsNullOrWhiteSpace(json))
                favorites = JsonConvert.DeserializeObject<List<FavoriteModel>>(json);
            return favorites;
        }

        private void SetSession(List<FavoriteModel> favorites)
        {
            var json = JsonConvert.SerializeObject(favorites);
            HttpContext.Session.SetString(_SESSIONKEY, json);
        }
    }
}
