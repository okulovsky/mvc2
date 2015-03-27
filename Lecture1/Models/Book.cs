using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecture1.Models
{

	public class Author
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}

	public class Book
	{
		public string Title { get; set; }
		public Author[] Authors { get; set; }
		public string Publisher { get; set;  }
		public int ImageId { get; set; }
		public int Year { get; set; }
	}
}