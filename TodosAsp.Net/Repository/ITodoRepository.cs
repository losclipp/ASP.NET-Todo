using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodosAsp.Net.Models;

namespace TodosAsp.Net.Repository
{
	public interface ITodoRepository
	{
		IEnumerable<Todo> GetAllTodos();
		Todo GetById(int id);
		Todo AddNew(Todo item);
		void DeleteById(int id);
		void EditById(int id, Todo newItem);
	}
}