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
                return _current.Children.First();
            }
            return _current;
        }

        public DialogueElement Next(DialogueResponse response)
        {
            if (_current != null && _current.HasChildren && _current.HasResponses)
            {
                return _current.Children.SingleOrDefault(c => c.ResponseId == response.Id);
            }
            return _current;
        }
    }

    public class DialogueElement
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Sequence { get; set; }
        public int? ResponseId { get; set; }
        public bool HasChildren { get { return Children != null && Children.Any(); } }
        public bool HasResponses { get { return Responses != null && Responses.Any(); } }
        public IEnumerable<DialogueElement> Children { get; set; }
        public IEnumerable<DialogueResponse> Responses { get; set; }
    }

    public class DialogueResponse
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Text { get; set; }
        public int Sequence { get; set; }
    }
}
