using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TodosAsp.Net.Models
{
	public class Todo
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string Project { get; set; }
		public bool Completed { get; set; }

	}
}