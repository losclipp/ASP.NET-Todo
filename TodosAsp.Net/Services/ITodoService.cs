using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodosAsp.Net.Models;

namespace TodosAsp.Net.Services
{
	public interface ITodoService
	{
		IEnumerable<Todo> GetAll();
		Todo GetById(int id);
		Todo Add(Todo todo);
		void Edit(int id, Todo newItem);
		void Delete(int id);
	}
}