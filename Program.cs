using System;

namespace RBMP.Games
{
    class Program
    {
        static GameRepository repositorio = new GameRepository();
        
        static void Main(string[] args)
        {
            string opcao = Menu();

            while (opcao.ToUpper() != "X") 
            {
                switch (opcao)
                {
                    case "1":
                        ListarGames();
                        break;
                    case "2":
                        InserirGame();
                        break;
                    case "3":
                        AtualizarGame();
                        break;
                    case "4":
                        ExcluirGame();
                        break;
                    case "5":
                        VizualizarGame();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = Menu();
            }
        }

        private static void ListarGames()
        {
            Console.WriteLine("Lista de games");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum game cadastrado");
                return;
            }

            foreach (var game in lista) 
            {
                Console.WriteLine($"{game.Id} - {game.GetTitulo()}");
            }
        }

        private static void InserirGame()
        {
            Console.WriteLine("Cadastrar novo game");

            foreach (int genero in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{genero}-{Enum.GetName(typeof(Genero), genero)}");
            }

            Console.WriteLine("Escolha um gênero: ");
            int generoOp = int.Parse(Console.ReadLine());

            Console.WriteLine("Título do game: ");
            string tituloOp = Console.ReadLine();

            Console.WriteLine("Ano de lançamento: ");
            int anoOp = int.Parse(Console.ReadLine());

            Console.WriteLine("Descrição do game: ");
            string descricaoOp = Console.ReadLine();

            Game game = new Game(repositorio.ProximoId(), (Genero)generoOp, tituloOp, descricaoOp, anoOp);
            repositorio.Insere(game);
        }

        private static void AtualizarGame()
        {
            Console.WriteLine("Atualizar game");
            Console.WriteLine("Digite o ID game");
            int idGame = int.Parse(Console.ReadLine());

            foreach (int genero in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{genero}-{Enum.GetName(typeof(Genero), genero)}");
            }

            Console.WriteLine("Escolha um gênero: ");
            int generoOp = int.Parse(Console.ReadLine());

            Console.WriteLine("Título do game: ");
            string tituloOp = Console.ReadLine();

            Console.WriteLine("Ano de lançamento: ");
            int anoOp = int.Parse(Console.ReadLine());

            Console.WriteLine("Descrição do game: ");
            string descricaoOp = Console.ReadLine();

            Game game = new Game(idGame, (Genero)generoOp, tituloOp, descricaoOp, anoOp);
            repositorio.Atualiza(idGame, game);
        }

        private static void ExcluirGame()
        {
            Console.WriteLine("Excluir game");
            Console.WriteLine("Digite o ID game");
            int idGame = int.Parse(Console.ReadLine());

            repositorio.Exclui(idGame);
        }

        private static void VizualizarGame()
        {
            Console.WriteLine("Digite o id do game:");
            int idGame = int.Parse(Console.ReadLine());

            var game = repositorio.RetornaPorId(idGame);

            Console.WriteLine(game);
        }
        
        private static string Menu() 
        {
            Console.WriteLine();
            Console.WriteLine("**** Games ****");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Lista de games");
            Console.WriteLine("2 - Novo game");
            Console.WriteLine("3 - Atualizar game");
            Console.WriteLine("4 - Excluir game");
            Console.WriteLine("5 - Visualizar game");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
