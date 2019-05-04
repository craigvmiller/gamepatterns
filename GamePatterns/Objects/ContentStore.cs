using System.Collections.Generic;
using System.Linq;

namespace GamePatterns.Objects
{
    public interface IContentStore
    {
        void Add(string key, object value);
        T Get<T>(string key) where T : class;
    }

    public class ContentStore : IContentStore
    {
        private Dictionary<string, object> _content;

        public ContentStore()
        {
            _content = new Dictionary<string, object>();
        }

        public void Add(string key, object value)
        {
            _content.Add(key, value);
        }

        public T Get<T>(string key) where T : class
        {
            return _content.SingleOrDefault(c => c.Key == key) as T;
        }
    }
}
