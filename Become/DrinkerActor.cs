using System;
using Akka.Actor;

namespace Become
{
    public class DrinkerActor : ReceiveActor
    {
        private int _currentBeers;
        private const int MaxBeers = 3;
        public DrinkerActor()
        {
            Sober();
        }

        private void Sober()
        {
            Receive<DrinkBeer>(drink =>
            {                
                _currentBeers++;
                Console.WriteLine("That's your beer nr: {0}", _currentBeers);
                if (_currentBeers > MaxBeers)
                {
                    Console.WriteLine("The guy is drunk...");

                    BecomeStacked(Drunk);
                }
            });

            Receive<Rest3Hours>(rest =>
            {
                Console.WriteLine("No need to rest yet...");
            });
        }

        private void Drunk()
        {
            Receive<DrinkBeer>(drink =>
            {
                Console.WriteLine("This guy is already drunk...");
            });

            Receive<Rest3Hours>(rest =>
            {
                Console.WriteLine("Sleeping for 3 hours...");
                UnbecomeStacked();
            });
        }
    }

    public class DrinkBeer
    { }

    public class Rest3Hours
    { }	
}