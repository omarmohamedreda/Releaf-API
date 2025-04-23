using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Releaf.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Releaf.EF
{
	public class ApplicationDbContext: IdentityDbContext<IdentityUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Plant> Plants { get; set; }
		public DbSet<Garden> Gardens { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Campaing> Campaings { get; set; }
		


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
	
}
