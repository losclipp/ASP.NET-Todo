using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodosAsp.Net.Models;
using System.Data.Entity.Core;

namespace TodosAsp.Net.Repository
{
	public class TodoRepository : ITodoRepository
	{
		private TodoContext _db = new TodoContext();

		public Todo AddNew(Todo item)
		{
			_db.Todoes.Add(item);
			_db.SaveChanges();
			return item;
		}
		public void DeleteById(int id)
		{
			var item = _db.Todoes.Find(id);
			_db.Todoes.Remove(item);
			_db.SaveChanges();
		}
		public void EditById(int id, Todo newItem)
		{
			if (_db.Todoes.Any(x => x.Id == id))
			{
				_db.Entry(newItem).State = EntityState.Modified;
				_db.SaveChanges();
			}
			else
			{
				throw new ObjectNotFoundException(string.Format("There is no Todo object with Id = {0}", id));
			};
		}
		public IEnumerable<Todo> GetAllTodos()
		{
			return _db.Todoes;
		}
		public Todo GetById(int id)
		{
			return _db.Todoes.Find(id);
		}

	}
}