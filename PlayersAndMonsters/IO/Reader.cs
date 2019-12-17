namespace PlayersAndMonsters.IO
{
    using PlayersAndMonsters.IO.Contracts;
    using System;
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
