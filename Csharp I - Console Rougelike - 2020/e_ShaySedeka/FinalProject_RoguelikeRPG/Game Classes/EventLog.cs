using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_RoguelikeRPG
{
    class EventLog
    {
        
        Queue<GameEvent> events;
   
        public Queue<GameEvent> Events { get => events; set => events = value; }

        public EventLog()
        {
            this.events = new Queue<GameEvent>();
        }

        public void AddEvent(String content)
        {
            // add the new event
            GameEvent eventToAdd = new GameEvent(content, DateTime.Now.ToString("HH:mm:ss"));
            this.Events.Enqueue(eventToAdd);

            //dequeue the last event if log length is over the limit
            if(this.Events.Count > GameDefinitions.MaxEventLogLength)
            {
                this.Events.Dequeue();
            }
        }

        public void PrintEventLog()
        {
            Console.WriteLine("Event Log:\n");
            for (int i = this.events.Count - 1; i >= 0; i --)
            {
                Console.WriteLine(this.events.ElementAt(i).ToString());
            }
        }
    }
}
