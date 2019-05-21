using System.Collections.Generic;
using GamePatterns.Commands;
using GamePatterns.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GamePatterns.States
{
    class DialogueState : IGameState
    {
        private DialogueTree _dialogue;
        private DialogueElement _current;
        private string _displayDialogue;
        private SpriteFont _font;

        public bool Completed { get; set; }

        public DialogueState(ContentManager content)
        {
            _dialogue = new DialogueTree();
            _font = content.Load<SpriteFont>("font");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, _displayDialogue, new Vector2(100, 400), Color.White);
        }

        public void HandleInputCommands(IEnumerable<IGameCommand> commands)
        {
        }

        public void Sleep()
        {
        }

        public void Update(GameTime gameTime)
        {
            _current = _dialogue.Next();
        }

        public void Wake()
        {
        }
    }
}
