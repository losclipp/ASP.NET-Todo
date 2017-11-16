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
using TodosAsp.Net.Models;
using System.Web.Http.Cors;
using TodosAsp.Net.Repository;
using TodosAsp.Net.Services;

namespace TodosAsp.Net.Controllers
{
	[EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
	public class TodoController : ApiController
    {
		private ITodoService _service;

        public TodoController(ITodoService service)
		{
			_service = service;
		}

		// GET: api/Todo
		public IEnumerable<Todo> GetTodoes()
        {
            return _service.GetAll();
        }

        // GET: api/Todo/5
        [ResponseType(typeof(Todo))]
        public IHttpActionResult GetTodo(int id)
        {
			var todo = _service.GetById(id);

			if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // PUT: api/Todo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTodo(int id, [FromBody]Todo todo)
        {
            try
            {
				_service.Edit(id, todo);
            }
            catch (Exception ex)
            {
				return BadRequest(ex.Message);
			}

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Todo
        [ResponseType(typeof(Todo))]
        public IHttpActionResult PostTodo([FromBody]Todo todo)
        {
            try
			{
				_service.Add(todo);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
            return CreatedAtRoute("DefaultApi", new { id = todo.Id }, todo);
        }

        // DELETE: api/Todo/5
        [ResponseType(typeof(Todo))]
        public IHttpActionResult DeleteTodo(int id)
        {
			try
			{
				_service.Delete(id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
            return Ok(id);
        }
    }
}