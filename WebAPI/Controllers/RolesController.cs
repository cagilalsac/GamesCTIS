    #nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
    using DataAccess.Contexts;
    using DataAccess.Entities;
using Business.Services;
using Business.Models;

//Generated from Custom Template.
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        // TODO: Add service injections here
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/Roles
        [HttpGet]
        public IActionResult Get()
        {
            List<RoleModel> roleList = _roleService.Query().ToList(); // TODO: Add get collection service logic here
            return Ok(roleList);
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RoleModel role = _roleService.Query().SingleOrDefault(r => r.Id == id); // TODO: Add get item service logic here
			if (role == null)
            {
                return NotFound();
            }
			return Ok(role);
        }

		// POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Post(RoleModel role)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                var result = _roleService.Add(role);
                if (result.IsSuccessful)
			        return CreatedAtAction("Get", new { id = role.Id }, role);
                ModelState.AddModelError("PostRole", result.Message);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public IActionResult Put(RoleModel role)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                var result = _roleService.Update(role);
                if (result.IsSuccessful)
                    return Ok(role);
                ModelState.AddModelError("PutRole", result.Message);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // TODO: Add delete service logic here
            var result = _roleService.Delete(id);
            if (result.IsSuccessful)
                return NoContent();
            return StatusCode(500, result.Message);
        }
	}
}
