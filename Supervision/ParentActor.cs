using System;
using Akka.Actor;

namespace Supervision
{
    public class ParentActor : UntypedActor
    {
        private int _errorNr = 0;
        
        protected override void OnReceive(object message)
        {
            if (message is StartProcess)
            {
                Context.ActorOf(Props.Create(() => new ChildActor(_errorNr)));
                _errorNr++;
            }

        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(
                5, //nr of retries
                TimeSpan.FromSeconds(5), // withinTimeRange
                x => // localOnlyDecider
                {
                    //we just ignore the error and keep going.
                    if (x is ArithmeticException) return Directive.Resume;

                    //Error that we cannot recover from, stop the failing actor
                    else if (x is NotSupportedException) return Directive.Stop;

                    //In all other cases, just restart the failing actor
                    else return Directive.Restart;
                });
        }
    }
}