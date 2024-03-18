using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IPublisherService
    {
        IQueryable<PublisherModel> Query();
        Result Add(PublisherModel model);
        Result Update(PublisherModel model);
        Result Delete(int id);
    }

    public class PublisherService : ServiceBase, IPublisherService
    {
		public PublisherService(Db db) : base(db)
		{
		}

		public IQueryable<PublisherModel> Query()
        {
            return _db.Publishers.Include(p => p.Games).Select(p => new PublisherModel()
            {
                // entity properties
                Guid = p.Guid,
                Id = p.Id,
                Name = p.Name,

                // extra properties
                Games = string.Join("<br />", p.Games.Select(g => g.Name))
            });
        }

        public Result Add(PublisherModel model)
        {
            if (_db.Publishers.Any(p => p.Name.ToLower() == model.Name.ToLower().Trim()))
                return new ErrorResult("Publisher with the same name exists!");
            Publisher entity = new Publisher()
            {
                Guid = Guid.NewGuid().ToString(),
                Name = model.Name.Trim()
            };

            // Way 1:
            //_db.Publishers.Add(entity);
            // Way 2:
            _db.Add(entity);

            _db.SaveChanges();
            return new SuccessResult();
        }

        public Result Update(PublisherModel model)
        {
            if (_db.Publishers.Any(p => p.Id != model.Id && p.Name.ToLower() == model.Name.ToLower().Trim()))
                return new ErrorResult("Publisher with the same name exists!");
            Publisher entity = _db.Publishers.Find(model.Id);
            if (entity is null)
                return new ErrorResult("Publisher not found!");
            entity.Name = model.Name.Trim();

            // Way 1:
            //_db.Publishers.Update(entity);
            // Way 2:
            _db.Update(entity);

            _db.SaveChanges();
            return new SuccessResult();
        }

        public Result Delete(int id)
        {
            Publisher entity = _db.Publishers.Include(r => r.Games).SingleOrDefault(p => p.Id == id);
            if (entity is null)
                return new ErrorResult("Publisher not found!");
            if (entity.Games is not null && entity.Games.Any())
                return new ErrorResult("Publisher can't be deleted because it has relational games!");
            
            // Way 1:
            //_db.Publishers.Remove(entity);
            // Way 2:
            _db.Remove(entity);

            _db.SaveChanges();
            return new SuccessResult();
        }
    }
}
