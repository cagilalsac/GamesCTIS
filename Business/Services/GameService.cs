using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Results.Bases;

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
			return _db.Games.OrderByDescending(g => g.PublishDate).ThenByDescending(g => g.TotalSalesPrice).ThenBy(g => g.Name)
				.Select(g => new GameModel()
				{
					Guid = g.Guid,
					Id = g.Id,
					Name = g.Name,
					PublishDate = g.PublishDate,
					PublisherId = g.PublisherId,
					TotalSalesPrice = g.TotalSalesPrice
				});
		}

		public Result Add(GameModel model)
		{
			throw new NotImplementedException();
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
