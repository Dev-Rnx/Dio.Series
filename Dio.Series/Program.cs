using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

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

                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---DIO Séries---");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            Console.Write("\nInforme a opção desejada: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Listar séries");
            Console.ForegroundColor = ConsoleColor.White;

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.\n");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}\n", serie.RetornaId(), serie.RetornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Inserir série");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("\nDigite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("\nDigite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
                                        genero: (Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        ano: entradaAno, 
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }


    }
}
