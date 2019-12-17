namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class TrapCard : Card, ICard
    {
        private const int initialDamagePoints = 120;
        private const int initialHealthPoints = 5;
        public TrapCard(string name)
            : base(name, initialDamagePoints, initialHealthPoints)
        {
        }
    }
}
