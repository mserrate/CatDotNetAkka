using System;
using Akka.Actor;

namespace HelloAkka
{
    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            Receive<Greet>(greet => Console.WriteLine("Hello {0}", greet.Who));
        }
    }
}