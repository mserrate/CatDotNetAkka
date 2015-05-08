using System;
using Akka.Actor;

namespace Supervision
{
    public class ChildActor : ReceiveActor
    {
        private int _errorNr = 0;

        public ChildActor(int errorNr)
        {
            _errorNr = errorNr;

            Receive<DoSomething>(x => DoSomethingHandler(x));

            Self.Tell(new DoSomething());
        }

        protected override void PostStop()
        {
            Console.WriteLine("\n\n\nChildActor: {0} stopped", Self.Path);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine("\n\n\nChildActor: {0} restarted", Self.Path);
        }

        private void DoSomethingHandler(DoSomething message)
        {
            if (_errorNr == 0)
            {
                Console.WriteLine("Operation {0} OK", _errorNr);
            }
            else if (_errorNr == 1)
            {
                Console.WriteLine("Operation {0} ArithmeticException", _errorNr);
                throw new ArithmeticException();
            }
            else if (_errorNr == 2)
            {
                Console.WriteLine("Operation {0} NotSupportedException", _errorNr);
                throw new NotSupportedException();
            }
            else
            {
                Console.WriteLine("Operation {0} ArgumentOutOfRangeException", _errorNr);
                throw new ArgumentOutOfRangeException();
            }

        }
    }
}
