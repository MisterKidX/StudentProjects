using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_RoguelikeRPG
{
    class GameEvent
    {

        #region Class Members

        string content;
        string timestamp;

        #endregion

        #region Class Properties
       
        public string Content { get => content; set => content = value; }
        public string Timestamp { get => timestamp; set => timestamp = value; }

        #endregion

        public GameEvent(string content, string timestamp)
        {
            Content = content;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return String.Format("{0, -85}  {1, -20}","- "+ this.content, this.timestamp);
        }

    }
}
