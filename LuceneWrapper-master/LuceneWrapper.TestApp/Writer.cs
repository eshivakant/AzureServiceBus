using System.Collections.Generic;
using System.Linq;

namespace LuceneWrapper.TestApp
{
    public class Writer<T> : BaseWriter<T>
    {
        public Writer(string dataFolder)
            : base(dataFolder)
        {
        }

        public void AddUpdateObjectToIndex(T person)
        {
            AddUpdateItemsToIndex(new List<IndexedDocument<T>> { (IndexedDocument<T>)person });
        }

        public void AddUpdateObjectsToIndex(List<T> objects)
        {       
            AddUpdateItemsToIndex(objects.Select(p => (IndexedDocument<T>)p).ToList());
        }

        public void DeleteObjectFromIndex(T person)
        {
            DeleteItemsFromIndex(new List<IndexedDocument<T>> { (IndexedDocument<T>)person });
        }

        public void DeleteObjectFromIndex(string id)
        {
            DeleteItemsFromIndex(new List<IndexedDocument<T>> { new IndexedDocument<T> { Id = id } });
        }
    }
}
