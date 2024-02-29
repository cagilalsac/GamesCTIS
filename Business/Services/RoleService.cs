using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IRoleService
    {
        IQueryable<RoleModel> Query();
        Result Add(RoleModel model);
    }

    public class RoleService : IRoleService
    {
        private readonly Db _db;

        public RoleService(Db db)
        {
            _db = db;
        }

        public IQueryable<RoleModel> Query()
        {
            return _db.Roles.Include(r => r.Users).OrderByDescending(r => r.Users.Count).ThenBy(r => r.Name).Select(roleEntity => new RoleModel()
            {
                Guid = roleEntity.Guid,
                Id = roleEntity.Id,
                Name = roleEntity.Name,

                UserCount = roleEntity.Users.Count,
                Users = string.Join("<br />", roleEntity.Users.OrderBy(u => u.UserName).Select(u => u.UserName))
            });
        }

        public Result Add(RoleModel model)
        {
            // Way 1:
            //Role existingRole = _db.Roles.FirstOrDefault(r => r.Name.ToLower() == model.Name.ToLower().Trim()); // case insensitive
            //if (existingRole is not null)
            //    return new ErrorResult("Role with the same name exists!");
            // Way 2:
            if (_db.Roles.Any(r => r.Name.ToLower() == model.Name.ToLower().Trim()))
                return new ErrorResult("Role with the same name exists!");
            Role entity = new Role()
            {
                Guid = Guid.NewGuid().ToString(),
                Name = model.Name.Trim(),
            };
            _db.Roles.Add(entity);
            _db.SaveChanges();
            return new SuccessResult("Role created successfully.");
        }
    }
}
