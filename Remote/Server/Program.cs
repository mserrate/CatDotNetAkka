using System;
using Akka.Actor;
using Akka.Configuration;
using Shared;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(@"
            akka {
                actor {
                    provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                }
            
                remote {
                    helios.tcp {
                        port = 8089
                        hostname = localhost
                    }
                }
            }
            ");

            using (ActorSystem system = ActorSystem.Create("MyServer", config))
            {
                system.ActorOf<GreetingActor>("greeter");
                Console.ReadKey();
            }
        }
    }
}