using System;
using System.Collections.Generic;

namespace CSharpIntermediate
{
    public class HttpCookie
    {
        private readonly Dictionary<string, string> _dictionary;
        public DateTime Expiry { get; set; }

        // Method: Constructor
        public HttpCookie()
        {
            _dictionary = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }
    }
}
