using System;

namespace DIO.Series
{
	public class Serie : EntidadeBase
	{
		public Serie(int id, Genero genero, string titulo, string descricao, int ano)
		{
			this.Id = Id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
			this.Excluido = false;
		}

		public Genero Genero { get; protected set; }
		public string Titulo { get; protected set; }
		public string Descricao { get; protected set; }
		public int Ano { get; protected set; }
		public bool Excluido { get; protected set; }

		public void Exclui()
		{
			this.Excluido = true;
		}

		public override string ToString()
		{
			return "Gênero: " + this.Genero + Environment.NewLine +
				"Título: " + this.Titulo + Environment.NewLine +
				"Descrição: " + this.Descricao + Environment.NewLine +
				"Ano de Início: " + this.Ano + Environment.NewLine +
				"Excluído: " + this.Excluido;
		}

		public override bool Equals(object obj)
		{
			if (obj is not Serie)
				return false;

			var objSerie = obj as Serie;
			return this.Id == objSerie.Id;
		}

		public override int GetHashCode()
		{
			return Id;
		}
	}

}