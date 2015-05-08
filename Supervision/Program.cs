using System;
using Akka.Actor;

namespace Supervision
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ActorSystem system = ActorSystem.Create("mySystem"))
            {
                var parent = system.ActorOf<ParentActor>();
                while (true)
                {
                    Console.ReadLine();
                    
                    parent.Tell(new StartProcess());
                }
            }
        }
    }
}