namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CardRepository : ICardRepository
    {
        private Dictionary<string, ICard> cardRepository;
        public CardRepository()
        {
            this.cardRepository = new Dictionary<string, ICard>();
        }
        public int Count => this.cardRepository.Count();

        public IReadOnlyCollection<ICard> Cards => this.cardRepository.Values.ToList().AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (this.cardRepository.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cardRepository.Add(card.Name, card);
        }

        public ICard Find(string name)
        {
            return this.cardRepository.FirstOrDefault(x => x.Key == name).Value;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            return this.cardRepository.Remove(card.Name);
        }
    }
}
