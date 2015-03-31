using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecture3.Models
{
	public interface IBookRepository
	{
		IEnumerable<Book> Books { get; }
	}
}