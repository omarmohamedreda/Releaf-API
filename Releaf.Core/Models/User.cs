﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Releaf.Core.Models
{
	public class User : IdentityUser
	{
		public string Name { get; set; } = string.Empty;

		public Garden Garden { get; set; }


	}
}
