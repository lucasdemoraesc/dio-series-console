using System;

namespace DIO.Series
{
	class Program
	{
		private static SerieRepositorio serieRepositorio = new SerieRepositorio();

		static void Main(string[] args)
		{
			int opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario != 7)
			{
				switch (opcaoUsuario)
				{
					case 1:
						ListarSeries();
						break;

					case 2:
						InserirSerie();
						break;

					case 3:
						AtualizarSerie();
						break;

					case 4:
						ExcluirSerie();
						break;

					case 5:
						VisualizarSerie();
						break;

					case 6:
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
				opcaoUsuario = ObterOpcaoUsuario();
			}
		}

		private static void VisualizarSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            Serie serie = serieRepositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
		}

		private static void ExcluirSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            serieRepositorio.Exclui(indiceSerie);
		}

		private static void AtualizarSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            Serie serieAlterar = ObterDadosSerie();
            serieAlterar.GetType().GetProperty("Id").SetValue(serieAlterar, indiceSerie);
            serieRepositorio.Atualiza(serieAlterar);
		}

		private static void ListarSeries()
		{
			Console.WriteLine("Lista de Séries");
			var lista = serieRepositorio.Lista();

			if (lista.Count > 0)
			{
				lista.ForEach(serie =>
				{
					Console.WriteLine($"#ID {serie.Id}: {serie.Titulo} {(serie.Excluido ? "- Excluído" : "")}");
				});
			}
			else
				Console.WriteLine("Lista de séries vazia...");
		}

		private static void InserirSerie()
		{
			Serie novaSerie = ObterDadosSerie();
			serieRepositorio.Insere(novaSerie);
		}

		private static Serie ObterDadosSerie()
		{
			foreach (int item in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine($"\t{item} - {Enum.GetName(typeof(Genero), item)}");
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o título da série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: serieRepositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
            return novaSerie;
		}

		private static int ObterOpcaoUsuario()
		{
			Console.WriteLine(Environment.NewLine + "Informe a opção desejada:");

			Console.WriteLine("\t1 - Listar séries");
			Console.WriteLine("\t2 - Inserir nova série");
			Console.WriteLine("\t3 - Atualizar série");
			Console.WriteLine("\t4 - Excluir série");
			Console.WriteLine("\t5 - Visualizar série");
			Console.WriteLine("\t6 - Limpar Tela");
			Console.WriteLine("\t7 - Sair");
			Console.Write("=> ");

			int opcaoUsuario = int.Parse(Console.ReadLine());
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
