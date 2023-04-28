namespace Laba1
{
    public class Book
    {
        public int ID { get; }
        public string Title { get; }
        public string Author { get; }
        public int Published { get; }
        public int Cabinetnumber { get; }
        public int Shelfnumber { get; }

        public Book(int id, string title, string author, int published, int cabinetnumber, int shelfnumber)
        {
            ID = id;
            Title = title;
            Author = author;
            Published = published;
            Cabinetnumber = cabinetnumber;
            Shelfnumber = shelfnumber;
        }
    }
}