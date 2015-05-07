using System;
using Akka.Actor;

namespace HelloAkka
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //container of actors
            var system = ActorSystem.Create("MySystem");
            
            //proxy to the actor's instance
            var greeter = system.ActorOf<GreetingActor>("greeter");
            
            //sends message
            greeter.Tell(new Greet("CatDotNet"));
            
            Console.ReadLine();
        }
    }
}