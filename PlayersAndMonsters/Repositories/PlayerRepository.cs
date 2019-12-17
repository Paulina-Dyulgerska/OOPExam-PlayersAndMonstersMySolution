namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository
    {
        private Dictionary<string, IPlayer> playerRepository;

        public PlayerRepository()
        {
            this.playerRepository = new Dictionary<string, IPlayer>();
        }
        public int Count => this.playerRepository.Count();

        public IReadOnlyCollection<IPlayer> Players => this.playerRepository.Values.ToList().AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (this.playerRepository.ContainsKey(player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.playerRepository.Add(player.Username, player);
        }

        public IPlayer Find(string username)
        {
            return this.playerRepository.FirstOrDefault(x => x.Key == username).Value;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            return this.playerRepository.Remove(player.Username);
        }
    }
}
