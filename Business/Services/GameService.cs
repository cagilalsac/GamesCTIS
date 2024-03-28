using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Business.Services
{
	public interface IGameService
	{
		IQueryable<GameModel> Query();
		Result Add(GameModel model);
		Result Update(GameModel model);
		Result Delete(int id);
		List<GameModel> GetList() => Query().ToList();
		GameModel GetItem(int id) => Query().SingleOrDefault(g => g.Id == id);
	}

	public class GameService : ServiceBase, IGameService
	{
		public GameService(Db db) : base(db)
		{
		}

		public IQueryable<GameModel> Query()
		{
			return _db.Games.Include(g => g.Publisher).Include(g => g.UserGames).ThenInclude(ug => ug.User)
				.OrderByDescending(g => g.PublishDate).ThenByDescending(g => g.TotalSalesPrice).ThenBy(g => g.Name)
				.Select(g => new GameModel()
				{
					// entity properties
					Guid = g.Guid,
					Id = g.Id,
					Name = g.Name,
					PublishDate = g.PublishDate,
					PublisherId = g.PublisherId,
					TotalSalesPrice = g.TotalSalesPrice,

					// extra properties
					PublisherOutput = g.Publisher.Name,

                    // Way 1:
                    //TotalSalesPriceOutput = g.TotalSalesPrice != null ? g.TotalSalesPrice.Value.ToString("C2", new CultureInfo("en-US")) : "", // tr-TR
                    // Way 2:
                    //TotalSalesPriceOutput = g.TotalSalesPrice.HasValue ? g.TotalSalesPrice.Value.ToString("C2", new CultureInfo("en-US")) : string.Empty,
                    // Way 3: 
                    //TotalSalesPriceOutput = g.TotalSalesPrice.HasValue ? g.TotalSalesPrice.Value.ToString("C2") : string.Empty, // N: number format, C: currency format, 2: number of decimal digits
                    // Way 4: Managing CultureInfo in MvcControllerBase
                    TotalSalesPriceOutput = (g.TotalSalesPrice ?? 0).ToString("C2"),

                    // Way 1:
                    //PublishDateOutput = g.PublishDate.HasValue ? g.PublishDate.Value.ToString("MM/dd/yyyy HH:mm:ss", new CultureInfo("en-US")) : string.Empty, // 2 digits month/2 digits day/4 digits year 2 digits hour:2 digits minute:2 digits second
                    // Way 2:
                    //PublishDateOutput = g.PublishDate.HasValue ? g.PublishDate.Value.ToString("MM/dd/yyyy", new CultureInfo("en-US")) : string.Empty
                    // Way 3: Managing CultureInfo in MvcControllerBase
					PublishDateOutput = g.PublishDate.HasValue ? g.PublishDate.Value.ToString("MM/dd/yyyy") : string.Empty,

					Users = g.UserGames.Select(ug => new UserModel()
					{
						UserName = ug.User.UserName,
						Status = ug.User.Status
						// other properties can be assigned if needed
					}).ToList()
                });
		}

		public Result Add(GameModel model)
		{
			if (_db.Games.Any(g => g.Name.ToLower() == model.Name.ToLower().Trim()))
				return new ErrorResult("Game with the same name exists!");
			Game entity = new Game()
			{
				// Way 1: Instead of assigning Guid in services' Create method, Guid can be assigned in Record abstract base class
				//Guid = Guid.NewGuid().ToString(),
				Name = model.Name.Trim(),
				PublishDate = model.PublishDate,
				TotalSalesPrice = model.TotalSalesPrice,
				PublisherId = model.PublisherId,

				// Way 2: filling entity's UserGames collection elements (ternary operator)
				//UserGames = model.UsersInput is null ? null : model.UsersInput.Select(userInput => new UserGame()
				//{
				//	UserId = userInput
				//}).ToList()
				// Way 3: filling entity's UserGames collection elements
				UserGames = model.UsersInput?.Select(userInput => new UserGame()
				{
					UserId = userInput
				}).ToList()
			};

			// Way 1: filling entity's UserGames collection elements
			//entity.UserGames = new List<UserGame>();
			//foreach (int userInput in model.UsersInput)
			//{
			//	entity.UserGames.Add(new UserGame()
			//	{
			//		UserId = userInput
			//	});
			//}

			_db.Games.Add(entity);
			_db.SaveChanges();

			model.Id = entity.Id;

			return new SuccessResult();
		}

		public Result Update(GameModel model)
		{
			throw new NotImplementedException();
		}

		public Result Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
