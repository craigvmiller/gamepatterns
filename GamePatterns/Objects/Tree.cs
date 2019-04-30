using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public class DialogueTree
    {
        private IEnumerable<DialogueElement> all;
        private DialogueElement current;

        public DialogueElement Next()
        {
            if (current != null && current.HasChildren && !current.HasResponses)
            {
                return current.Children.First();
            }
            return current;
        }

        public DialogueElement Next(DialogueResponse response)
        {
            if (current != null && current.HasChildren && current.HasResponses)
            {
                return current.Children.SingleOrDefault(c => c.ResponseId == response.Id);
            }
            return current;
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
