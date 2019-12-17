namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO.Contracts;
    using System;
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IManagerController controller;

        public Engine(IWriter writer, IReader reader, IManagerController controller)
        {
            this.writer = writer;
            this.reader = reader;
            this.controller = controller;
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();

                var result = string.Empty;

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        var playerType = input[1];
                        var playerName = input[2];
                        result = controller.AddPlayer(playerType, playerName);
                    }
                    else if (input[0] == "AddCard")
                    {
                        var cardtype = input[1];
                        var cardName = input[2];
                        result = controller.AddCard(cardtype, cardName);
                    }
                    else if (input[0] == "AddPlayerCard")
                    {
                        var playerName = input[1];
                        var cardName = input[2];
                        result = controller.AddPlayerCard(playerName, cardName);
                    }
                    else if (input[0] == "Fight")
                    {
                        var attackUser = input[1];
                        var enemyUser = input[2];
                        result = controller.Fight(attackUser, enemyUser);
                    }
                    else if (input[0] == "Report")
                    {
                        result = controller.Report();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
