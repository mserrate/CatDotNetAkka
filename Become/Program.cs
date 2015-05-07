using System;
using Akka.Actor;

namespace Become
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Use 'drink' to drink beer");
            Console.WriteLine("Use 'rest' to rest for 3 hours");
            using (ActorSystem system = ActorSystem.Create("mySystem"))
            {
                var drinker = system.ActorOf<DrinkerActor>();
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "drink")
                        drinker.Tell(new DrinkBeer());
                    if (input == "rest")
                        drinker.Tell(new Rest3Hours());
                }
            }
        }
    }
}