using System;
using Akka.Actor;

namespace Shared
{
    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            Receive<Greet>(greet => Console.WriteLine("Hello {0}", greet.Who));
        }
    }
}