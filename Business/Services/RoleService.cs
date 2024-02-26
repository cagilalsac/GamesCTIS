using Business.Models;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IRoleService
    {
        IQueryable<RoleModel> Query();
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
    }
}
