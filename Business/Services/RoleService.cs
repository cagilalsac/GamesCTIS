﻿using Business.Models;
using DataAccess.Contexts;

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
            return _db.Roles.Select(roleEntity => new RoleModel()
            {
                Guid = roleEntity.Guid,
                Id = roleEntity.Id,
                Name = roleEntity.Name,
            });
        }
    }
}