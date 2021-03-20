using System.Collections.Generic;
using System.Linq;

namespace DIO.Series
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
		private List<Serie> series = new List<Serie>();

		public void Insere(Serie entidade)
		{
			if(!series.Where(serie => serie.Equals(entidade)).Any())
                this.series.Add(entidade);
		}

		public void Atualiza(Serie entidade)
		{
			series[RetornaIndice(entidade)] = entidade;
		}

		public void Exclui(int id)
		{
            Serie serieRemover = this.RetornaPorId(id);
			serieRemover.Exclui();
		}

		public List<Serie> Lista()
		{
			return series;
		}

		public Serie RetornaPorId(int id)
		{
			return series.FirstOrDefault(serie => serie.Id == id);
		}

		public int RetornaIndice(Serie entidade)
		{
			return series.FindIndex(serie => serie.Equals(serie));
		}

		public int ProximoId()
		{
			return series.Count();
		}
	}
}