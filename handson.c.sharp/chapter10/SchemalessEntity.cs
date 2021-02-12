using System;
using System.Collections;
using System.Collections.Generic;

namespace handson.c.sharp.chapter10
{
    public class SchemalessEntity : IEnumerable<KeyValuePair<string, object>>
    {
        private readonly IDictionary<string, object> properties = new Dictionary<string, object>();

        public string Key { get; set; }
        public string ParentKey { get; set; }

        public object this[string propertyKey]
        {
            get => properties[propertyKey];
            set => properties[propertyKey] = value;
        }

        public void Add(string propertyKey, object value)
        {
            properties.Add(propertyKey, value);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() =>
            properties.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => properties.GetEnumerator();
    }
}
