namespace P02._Books_Before
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string TurnPage(int page)
        {
            return "Current page";
        }
    }
}
