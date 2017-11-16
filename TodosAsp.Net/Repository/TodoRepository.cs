using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodosAsp.Net.Models;

namespace TodosAsp.Net.Repository
{
	public class TodoRepository : ITodoRepository
	{
		private TodoContext _db = new TodoContext();

		public void AddNew(Todo item)
		{
			_db.Todoes.Add(item);
			_db.SaveChanges();
		}
		public void DeleteById(int id)
		{
			var item = _db.Todoes.Find(id);
			_db.Todoes.Remove(item);
			_db.SaveChanges();
		}
		public void EditById(int id, Todo newItem)
		{
			_db.Entry(newItem).State = EntityState.Modified;
			_db.SaveChanges();
		}
		public IQueryable<Todo> GetAllTodos()
		{
			return _db.Todoes;
		}
		public Todo GetById(int id)
		{
			return _db.Todoes.Find(id);
		}

	}
}