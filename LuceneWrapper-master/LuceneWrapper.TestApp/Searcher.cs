namespace LuceneWrapper.TestApp
{
    public class Searcher<T>:BaseSearcher<T>
    {
        public Searcher(string dataFolder) : base(dataFolder)
        {
        }

        public SearchResult SearchObjects<ADocument>(string searchTerm, string field=null)
        {
            return Search<IndexedDocument<T>>(searchTerm, field);
        }

    }
}
