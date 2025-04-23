using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Releaf.Core.Models
{
	public class Garden
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string UserId { get; set; }
		public User User { get; set; }

	}
}
