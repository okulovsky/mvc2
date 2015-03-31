using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecture3.Models
{
	public class CurrentDateProvider : ICurrentDateProvider
	{
		public DateTime Now
		{
			get { return DateTime.Now; }
		}
	}
}