using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodosAsp.Net.Models
{
	public class TodoDbInitializer : DropCreateDatabaseAlways<TodoContext> 
	{
		protected override void Seed(TodoContext context)
		{
			context.Todoes.Add(new Todo { Id = 1, Title = "OLOLO", Project = "Project_1", Completed = false });
			context.Todoes.Add(new Todo { Id = 2, Title = "XOXOXO", Project = "Project_5", Completed = false });
			context.Todoes.Add(new Todo { Id = 3, Title = "JUST DO IT", Project = "Project_4", Completed = false });
			context.Todoes.Add(new Todo { Id = 4, Title = "198543", Project = "Project_4", Completed = false });
			context.Todoes.Add(new Todo { Id = 5, Title = "BLA-BLA-BLA", Project = "Project_6", Completed = false });
			context.Todoes.Add(new Todo { Id = 6, Title = "DO-DO-DO", Project = "Project_8", Completed = false });
			context.Todoes.Add(new Todo { Id = 7, Title = "some title", Project = "Project_11", Completed = false });
			context.Todoes.Add(new Todo { Id = 8, Title = "^-^", Project = "Project_2", Completed = false });
			context.Todoes.Add(new Todo { Id = 9, Title = "Real title", Project = "Project_8", Completed = false });
			context.Todoes.Add(new Todo { Id = 10, Title = "6)", Project = "Project_6", Completed = false });
		}
	}
}