using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationForm.Models;
using ReservationForm.Repositories;

namespace ReservationForm.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RezervasyonController : ControllerBase
	{
		private readonly IRezervasyon _rezervasyon;

		public RezervasyonController(IRezervasyon rezervasyon)
		{
			_rezervasyon = rezervasyon;
		}
		[HttpGet]
		public async Task<IEnumerable<Rezervasyon>> GetRezervasyon()
		{
			return await _rezervasyon.GetAll();
		}

		[HttpPost]
		public async Task<ActionResult<Rezervasyon>> PostRezervasyon([FromBody] Rezervasyon rezervasyon)
		{
			var rezervasyonResult = await _rezervasyon.Create(rezervasyon);
			return CreatedAtAction(nameof(GetRezervasyon), new {id = rezervasyon.rezervasyonId}, rezervasyon);
		}
	}
}
