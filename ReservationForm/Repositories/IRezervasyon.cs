using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ReservationForm.Models;

namespace ReservationForm.Repositories
{
	public interface IRezervasyon
	{
		Task<IEnumerable<Rezervasyon>> GetAll(Expression<Func<Rezervasyon, bool>> filter = null);
		Task<Rezervasyon> Create(Rezervasyon rezervasyon);
	}
}
