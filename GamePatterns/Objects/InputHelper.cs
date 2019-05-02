using GamePatterns.Commands;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GamePatterns.Objects
{
    public class InputHelper
    {
        public IDictionary<Keys[], IGameCommand> InputCommands { get; set; }

        public InputHelper()
        {
            InputCommands = new Dictionary<Keys[], IGameCommand>();
            InputCommands.Add(new Keys[] { Keys.W }, null);
        }
    }
}
