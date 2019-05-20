using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public class DialogueTree
    {
        private IEnumerable<DialogueElement> _all;
        private DialogueElement _current;

        public DialogueElement Next()
        {
            if (_current != null && _current.HasChildren && !_current.HasResponses)
            {
                _current = _current.Children.First();
            }
            return _current;
        }

        public DialogueElement Next(DialogueResponse response)
        {
            if (_current != null && _current.HasChildren && _current.HasResponses)
            {
                _current = _current.Children.SingleOrDefault(c => c.ResponseId == response.Id);
            }
            return _current;
        }
    }
}
