using Lecture3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecture3.Infrastructure
{
	public interface IBookRepository
	{
		IEnumerable<Book> Books { get; }
	}
}