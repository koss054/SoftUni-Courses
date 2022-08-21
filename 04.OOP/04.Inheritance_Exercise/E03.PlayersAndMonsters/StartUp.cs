using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var elf = new Elf("Bruh22", 15);
            var darkKnight = new DarkKnight("Brat44", 30);
            var soulMaster = new SoulMaster("Bruder88", 60);

            Console.WriteLine(elf);
            Console.WriteLine(darkKnight);
            Console.WriteLine(soulMaster);
        }
    }
}
