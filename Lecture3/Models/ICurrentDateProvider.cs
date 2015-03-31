using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3.Models
{
	public interface ICurrentDateProvider
	{
		DateTime Now { get; }
	}
}
