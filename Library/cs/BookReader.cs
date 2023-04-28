namespace Laba1
{
    public class BookReader
    { //Book name;Reader name;Take date;Return date
        public Book Bookname { get; }
        public Reader Readername { get; }
        public DateTime Takedate { get; }
        public DateTime Returndate { get; }

        public BookReader(Book bookname, Reader readername, DateTime takedate, DateTime returndate)
        {
            Bookname = bookname;
            Readername = readername;
            Takedate = takedate;
            Returndate = returndate;
        }
    }
}