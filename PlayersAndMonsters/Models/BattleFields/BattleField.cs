namespace PlayersAndMonsters.Models.BattleFields
{

    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            IncreaseBeginnerPoints(attackPlayer);
            IncreaseBeginnerPoints(enemyPlayer);

            IncreaseHealthPointsWithBonus(attackPlayer);
            IncreaseHealthPointsWithBonus(enemyPlayer);

            while (true)
            {
                PlayerTakesDamage(attackPlayer, enemyPlayer);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                PlayerTakesDamage(enemyPlayer, attackPlayer);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private static void PlayerTakesDamage(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum());
        }
        private static void IncreaseHealthPointsWithBonus(IPlayer player)
        {
            var bonusHealthPoints = player.CardRepository.Cards.Select(x => x.HealthPoints).Sum();
            player.Health += bonusHealthPoints;
        }

        private static void IncreaseBeginnerPoints(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += 40;

                //player.CardRepository.Cards.Select(x => x.DamagePoints += 30);

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
