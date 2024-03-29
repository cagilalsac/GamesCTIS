﻿#nullable disable
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Controllers.Bases;

//Generated from Custom Template.
namespace MVC.Controllers
{
	public class GamesController : MvcControllerBase
    {
        // TODO: Add service injections here
        private readonly IGameService _gameService;
        private readonly IPublisherService _publisherService;
        private readonly IUserService _userService;

		public GamesController(IGameService gameService, IPublisherService publisherService, IUserService userService)
		{
			_gameService = gameService;
			_publisherService = publisherService;
			_userService = userService;
		}

		// GET: Games
		public IActionResult Index()
        {
            List<GameModel> gameList = _gameService.GetList(); // TODO: Add get collection service logic here
            return View("List", gameList);
        }

        // GET: Games/Details/5
        public IActionResult Details(int id)
        {
            GameModel game = _gameService.GetItem(id); // TODO: Add get item service logic here
            if (game == null)
            {
                // Way 1:
                //return NotFound();
                // Way 2:
                //return View("Error", "Game with ID " + id + " not found!");
                // Way 3:
                return View("Error", $"Game with ID {id} not found!");
            }
            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewData["PublisherId"] = new SelectList(_publisherService.Query().ToList(), "Id", "Name");
            ViewBag.Users = new MultiSelectList(_userService.GetList(), "Id", "UserName");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GameModel game)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                return RedirectToAction(nameof(Index));
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewData["PublisherId"] = new SelectList(new List<SelectListItem>(), "Value", "Text");
            return View(game);
        }

        // GET: Games/Edit/5
        public IActionResult Edit(int id)
        {
            GameModel game = null; // TODO: Add get item service logic here
            if (game == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewData["PublisherId"] = new SelectList(new List<SelectListItem>(), "Value", "Text");
            return View(game);
        }

        // POST: Games/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GameModel game)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                return RedirectToAction(nameof(Index));
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewData["PublisherId"] = new SelectList(new List<SelectListItem>(), "Value", "Text");
            return View(game);
        }

        // GET: Games/Delete/5
        public IActionResult Delete(int id)
        {
            GameModel game = null; // TODO: Add get item service logic here
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            return RedirectToAction(nameof(Index));
        }
	}
}
