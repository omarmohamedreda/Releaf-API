using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Releaf.Core.Models
{
	public class Plant
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Season { get; set; }
		public string Soil { get; set; }
		public string Sunlight { get; set; }
		public string Temperature { get; set; }
		public string hardinessZones { get; set; }
		public string soil_ph { get; set; }
		public string soil_type {  get; set; }
		public string day_sowing { get; set; }
		public string day_sprout { get; set; }
		public string day_vegetative { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }

		public List<string> ImageUrls { get; set; }

	}
}
