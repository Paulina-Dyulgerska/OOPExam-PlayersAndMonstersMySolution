namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class MagicCard : Card, ICard
    {
        private const int initialDamagePoints = 5;
        private const int initialHealthPoints = 80;
        public MagicCard(string name) 
            : base(name, initialDamagePoints, initialHealthPoints)
        {
        }
    }
}
