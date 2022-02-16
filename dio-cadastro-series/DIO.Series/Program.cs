using System;
using DIO.Series.Classes;
using DIO.Series.Enums;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            var opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;

                    case "6":
                        AvaliarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornarExcluido();
                Console.WriteLine("#ID {0}: {1} - Nota Geral: {2} -> {3}", serie.RetornarId(), serie.RetornarTitulo(), serie.RetornarNotaDaSerie(), (excluido ? "Não disponível" : "Disponível"));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            var novaSerie = ColetarDadosTela(true);

            repositorio.Inserir(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar série");

            var serie = ColetarDadosTela(false);

            repositorio.Atualizar(serie.Id, serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir série");

            Console.WriteLine("Digite o ID da série: ");
            var indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar série");

            Console.WriteLine("Digite o ID da série: ");
            var indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(indiceSerie);
            Console.WriteLine(serie);
        }

         private static void AvaliarSerie()
        {
            Console.WriteLine("Avaliar série");

            Console.WriteLine("Digite o ID da série: ");
            var indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a nota da série: ");
            var notaSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(indiceSerie);

            serie.AdicionarNota(notaSerie);

            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séires a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Avaliar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }

        private static Serie ColetarDadosTela(bool novaSerie)
        {
            var idSerie = repositorio.ProximoId();

            if (!novaSerie)
            {
                Console.WriteLine("Digite o ID da séire: ");
                idSerie = int.Parse(Console.ReadLine());
            }

            foreach (var i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", (int)i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            var entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            var entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de início da série: ");
            var entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            var entradaDescricao = Console.ReadLine();

            return new Serie(
                id: idSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);
        }
    }
}
