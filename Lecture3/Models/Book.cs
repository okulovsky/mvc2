using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecture3.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime AvailabilityDate { get; set; }
	}
}