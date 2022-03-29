using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationForm.Models
{
	public class RezervasyonResults
	{
		[Key]
		public int rezervasyonResultsId { get; set; }
		public bool rezervasyonYapilabilir { get; set; }
		public YerlesimAyrinti[] yerlesimAyrintis { get; set; }
	}

	public class YerlesimAyrinti
	{
		[Key]
		public int yerlesimAyrintiId { get; set; }
		public string VagonAdi { get; set; }
		public int KisiSayisi { get; set; }
	}
}
