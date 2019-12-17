namespace PlayersAndMonsters
{
    using PlayersAndMonsters.Core;
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO;
    using PlayersAndMonsters.IO.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            //IReader reader = new FileReader("../../../Input.txt");
            //IWriter writer = new FileWriter("../../../Output.txt");

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            //IPlayerRepository playerRepository = new PlayerRepository();
            //ICardRepository cardrepository = new CardRepository();
            //IBattleField battleField = new BattleField();

            //Judge gyrmi, ako dam constructor na controllera s parameters!!!!
            //IManagerController controller = new ManagerController(playerRepository, cardrepository, battleField);
            
            IManagerController controller = new ManagerController();

            IEngine engine = new Engine(writer, reader, controller);

            engine.Run();

            //(reader as FileReader).Dispose();
        }
    }
}