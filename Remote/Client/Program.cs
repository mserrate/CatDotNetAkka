using System;
using Akka.Actor;
using Akka.Configuration;
using Shared;

namespace Client
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
                        port = 8090
                        hostname = localhost
                    }
                }
            }
            ");

            using (var system = ActorSystem.Create("MyClient", config))
            {
                //get a reference to the remote actor
                var greeter = system
                    .ActorSelection("akka.tcp://MyServer@localhost:8089/user/greeter");
                //send a message to the remote actor
                greeter.Tell(new Greet("CatDotNet Remote!!"));

                Console.ReadLine();
            }
        }
    }
}