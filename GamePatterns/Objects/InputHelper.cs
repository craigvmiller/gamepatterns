using GamePatterns.Commands;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public class InputHelper
    {
        public IDictionary<Keys[], IGameCommand> InputCommands { get; set; }

        public InputHelper()
        {
            InputCommands = new Dictionary<Keys[], IGameCommand>();
            InputCommands.Add(new Keys[] { Keys.W }, new MoveCommand(Direction.North, new Microsoft.Xna.Framework.Vector2(0, -1)));
            InputCommands.Add(new Keys[] { Keys.D }, new MoveCommand(Direction.East, new Microsoft.Xna.Framework.Vector2(1, 0)));
            InputCommands.Add(new Keys[] { Keys.S }, new MoveCommand(Direction.South, new Microsoft.Xna.Framework.Vector2(0, 1)));
            InputCommands.Add(new Keys[] { Keys.A }, new MoveCommand(Direction.West, new Microsoft.Xna.Framework.Vector2(-1, 0)));
        }

        public IEnumerable<IGameCommand> HandleInput()
        {
            List<IGameCommand> result = new List<IGameCommand>();
            foreach (Keys key in Keyboard.GetState().GetPressedKeys())
            {
                result.AddRange(InputCommands.Where(c => c.Key.Contains(key)).Select(c => c.Value));
            }
            return result;
        }
    }
}
