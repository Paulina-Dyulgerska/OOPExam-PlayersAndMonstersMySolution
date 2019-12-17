namespace PlayersAndMonsters.Core
{
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository players;
        private ICardRepository cards;
        private IBattleField battleField;

        //Judge gyrmi, ako dam constructor na controllera s parameters!!!!
        //public ManagerController(IPlayerRepository players, ICardRepository cards, IBattleField battleField)
        //{
        //    this.players = players;
        //    this.cards = cards;
        //    this.battleField = battleField;
        //}

        public ManagerController()
        {
            this.players = new PlayerRepository();
            this.cards = new CardRepository();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = null;

            switch (type)
            {
                case "Beginner":
                    player = new Beginner(new CardRepository(), username);
                    break;
                case "Advanced":
                    player = new Advanced(new CardRepository(), username);
                    break;
            }

            players.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = null;

            switch (type)
            {
                case "Magic":
                    card = new MagicCard(name);
                    break;
                case "Trap":
                    card = new TrapCard(name);
                    break;
            }

            cards.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var card = this.cards.Find(cardName);
            var player = this.players.Find(username);
            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = this.players.Find(attackUser);
            var enemyPlayer = this.players.Find(enemyUser);

            this.battleField.Fight(attackPlayer, enemyPlayer);

            return string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
        }

        public string Report()
        {
            var str = new StringBuilder();

            foreach (var player in players.Players)
            {
                str.AppendFormat(ConstantMessages.PlayerReportInfo, 
                    player.Username, player.Health, player.CardRepository.Count);
                str.AppendLine();

                foreach (var card in player.CardRepository.Cards)
                {
                    str.AppendFormat(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints);
                    str.AppendLine();
                }

                str.AppendFormat(ConstantMessages.DefaultReportSeparator);
                str.AppendLine();
            }

            return str.ToString().TrimEnd();
        }
    }
}
