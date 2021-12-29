using System.Collections.Generic;
using System.Linq;
using RBMP.Games.Interfaces;

namespace RBMP.Games
{
    public class GameRepository : IRepository<Game>
    {
        private List<Game> games = new List<Game>();

        public void Atualiza(int id, Game entidade)
        {
            games[id] = entidade;
        }

        public void Exclui(int id)
        {
            games[id].Exclui();
        }

        public void Insere(Game entidade)
        {
            games.Add(entidade);
        }

        public List<Game> Lista()
        {
            return games.Where(g => !g.GetExcluido()).ToList();
        }

        public int ProximoId()
        {
            return games.Count;
        }

        public Game RetornaPorId(int id)
        {
            return games[id];
        }
    }
}