
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationForm.Models;

namespace ReservationForm.DataBase
{
	public class DatabaseDb :DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				@"Server=DESKTOP-DFORJ46;Database=RezervasyonsResult;Trusted_Connection=True;Integrated security=True;");
		}

		public DbSet<Rezervasyon> Rezervasyons { get; set; }
		public DbSet<RezervasyonResults> RezervasyonResults{ get; set; }
	}
}
