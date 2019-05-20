using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
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
}
