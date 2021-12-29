using System.Text;

namespace RBMP.Games
{
    public class Game :  EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Removido { get; set; }

        public Game(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Removido = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {this.Id}");
            sb.AppendLine($"Titulo: {this.Titulo}");
            sb.AppendLine($"Descricao: {this.Descricao}");
            sb.AppendLine($"Ano de lançamento: {this.Ano}");
            sb.AppendLine($"Gênero: {this.Genero}");

            return sb.ToString();
        }

        public string GetTitulo(){
            return this.Titulo;
        }

        public int GetId(){
            return this.Id;
        }

        public bool GetExcluido(){
            return this.Removido;
        }

         public void Exclui(){
            this.Removido = true;
        }
    }
}