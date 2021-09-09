using System;



namespace Cadastrodeseries
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
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
                        AtualizaSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizaSerie();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    case "X":
                        VisualizaSerie();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar o nosso serviço");
            Console.ReadLine();
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo a biblioteca de Séries");
            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Adicionar Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("6 - Limpar a Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries: ");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Lista Vazia");
                return;
            }
            foreach (var serie in lista)
            {
                if (serie.returnStatus() == true)
                {
                    Console.WriteLine("#ID {0} - Excluída", serie.returnId());
                }
                else
                {
                    Console.WriteLine("#ID {0} - {1}", serie.returnId(), serie.retornaNome());
                }
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine();
            Console.WriteLine("Adicione nova Séries: ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#ID {0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero, entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o Nome da série: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(repositorio.ProximaID(), (Genero)entradaGenero, entradaNome, entradaDescricao, entradaAno);

            repositorio.Insere(novaSerie);
        }
        private static void AtualizaSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int IndiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#ID {0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero, entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Digite o Nome da série: ");
            string entradaNome = Console.ReadLine();
            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(IndiceSerie, (Genero)entradaGenero, entradaNome, entradaDescricao, entradaAno);

            repositorio.Atualiza(IndiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da Série a ser excluída: ");
            int IndiceSerie = int.Parse(Console.ReadLine());
            repositorio.Excluir(IndiceSerie);
            
        }
        private static void VisualizaSerie()
        {
            Console.WriteLine("Digite o ID da Série a ser visualizada: ");
            int IndiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorID(IndiceSerie);
            Console.WriteLine(serie);
        }
        
    }
}
