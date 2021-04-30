using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview
{

    // An in memory implementation of IRepository<T>

    public class InMemoryRepository<T> : IRepository<T> where T : IStoreable
    {
        // Private collection for use in class, must be accessed by public methods
        private readonly IList<T> entities = new List<T>();
        
        public IEnumerable<T> All()
        {
            // Simply return all entities in private collection
            return entities;
        }

        public void Delete(IComparable id)
        {
            // Find the item by the passed Id remove from collection
            T item = FindById(id);
            entities.Remove(item);
        }

        public T FindById(IComparable id)
        {
            // Return either entry with matching Id or null value
            return entities.SingleOrDefault(i => i.Id == id);
        }

        public void Save(T item)
        {
            // Add passed item to private collection
            entities.Add(item);
        }
    }
}
