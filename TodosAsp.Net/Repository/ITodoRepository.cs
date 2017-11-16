using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodosAsp.Net.Models;

namespace TodosAsp.Net.Repository
{
	public interface ITodoRepository
	{
		IQueryable<Todo> GetAllTodos();
		Todo GetById(int id);
		void AddNew(Todo item);
		void DeleteById(int id);
		void EditById(int id, Todo newItem);
	}
}