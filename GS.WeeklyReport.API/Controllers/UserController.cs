using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GS.WeeklyReport.IService;
using GS.WeeklyReport.Service;
using WeeklyReport.Models;

namespace GS.WeeklyReport.API.Controllers
{
    public class UserController : ApiController
    {
        IUserService service = new UserService();

        // GET api/User
        public IQueryable<User> GetUser()
        {
            return service.LoadEntities(u => u.UserId != null).AsQueryable();
        }

        // GET api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(Guid id)
        {
            User user = service.LoadEntities(u => u.UserId == id).First();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT api/User/5
        public IHttpActionResult PutUser(Guid id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            try
            {
                service.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/User
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                service.Add(user);
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(Guid id)
        {
            User user = service.LoadEntities(u => u.UserId == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            service.Delete(user);
            return Ok(user);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool UserExists(Guid id)
        {
            return service.LoadEntities(u => u.UserId == id).Any();
        }
    }
}