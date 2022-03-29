using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationForm.DataBase;
using ReservationForm.Models;

namespace ReservationForm.Repositories
{
	public class RezervasyonRepository:IRezervasyon
	{
		private readonly DatabaseDb _context;

		public RezervasyonRepository(DatabaseDb context)
		{
			_context = context;
		}

		//public async Task<IEnumerable<Rezervasyon>> GetAll()
		//{
		//	return await _context.Rezervasyons.ToListAsync();
		//}
		public async Task<IEnumerable<Rezervasyon>> GetAll(Expression<Func<Rezervasyon, bool>> filter = null)
		{
			using (_context)
			{
				return filter == null
					? await _context.Set<Rezervasyon>().ToListAsync()
					: await _context.Set<Rezervasyon>().Where(filter).ToListAsync();
			}
		}

		//public async Task<Rezervasyon> Create(Rezervasyon rezervasyon)
		//{
		//	_context.Rezervasyons.Add(rezervasyon);
		//	await _context.SaveChangesAsync();
		//	return rezervasyon;
		//}
		public async Task<Rezervasyon> Create(Rezervasyon rezervasyon)
		{
			using (_context)
			{
				var addRezervasyon = _context.Entry(rezervasyon);
				addRezervasyon.State = EntityState.Added;
				await _context.SaveChangesAsync();
			}

			return rezervasyon;
		}
	}
}
