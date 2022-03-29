using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationForm.Models
{
	public class Rezervasyon
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int rezervasyonId { get; set; }
		public int RezervasyonYapilacakKisiSayisi { get; set; }
		public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
		public virtual ICollection<Tren> Trens { get; set; }
	}
	public class Tren
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int trenId { get; set; }
		public string Ad { get; set; }
		public virtual ICollection<Vagonlar> Vagonlars { get; set; }
	}
	public class Vagonlar
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int vagonId { get; set; }
		public string Ad { get; set; }
		public int Kapasite { get; set; }
		public int DolulukAdeti { get; set; }
	}
}
