using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodosAsp.Net.Models;
using TodosAsp.Net.Repository;

namespace TodosAsp.Net.Services
{
	public class TodoService : ITodoService
	{
		ITodoRepository _repository;

		public TodoService( ITodoRepository repository)
		{
			_repository = repository;
		}
		public IQueryable<Todo> GetAll()
		{
			try
			{
				return _repository.GetAllTodos();
			}
			catch (Exception ex)
			{
				// log
				throw;
			}
		}
		public Todo GetById(int id)
		{
			try
			{
				return _repository.GetById(id);
			}
			catch(Exception ex)
			{
				// log
				throw;
			}
		}
		public void Add(Todo todo)
		{
			if (!IsTodoValid(todo))
				throw new ArgumentException("New Todo is not valid");

			try
			{
				_repository.AddNew(todo);
			}
			catch(Exception ex)
			{
				// log
				throw;
			}
		}
		public void Edit(int id, Todo todo)
		{
			if (id != todo.Id)
				throw new ArgumentException("Id doesn't match with newItem.Id");
			if (!IsTodoValid(todo))
				throw new ArgumentException("Last edited Todo was not valid");

			try
			{
				_repository.EditById(id, todo);
			}
			catch (Exception ex)
			{
				// log
				throw;
			}
		}
		public void Delete(int id)
		{
			try
			{
				_repository.DeleteById(id);
			}
			catch (Exception ex)
			{
				// log
				throw;
			}
		}

		private bool IsTodoValid(Todo todo)
		{
			return  IsValidString(todo.Project) &&
					IsValidString(todo.Title);
		}
		private bool IsValidString(string str)
		{
			if ( str == null || str.Trim().Length == 0)
				return false;
			return true;
		}
	}
}