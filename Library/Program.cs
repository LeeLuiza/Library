using System;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace Laba1
{
    public class Program
    {
        public static void Main()
        {
            int errorbook = Checkfile.GetBooks("Book.csv");
            int errorread = Checkfile.GetReaders("Reader.csv");
            int errrorbookreader = Checkfile.GetBookReaders("BookReader.csv");

            Book[] book = Dataentry.Book("Book.csv");
            Reader[] reader = Dataentry.Reader("Reader.csv");
            BookReader[] bookreader = Dataentry.BookReaders("BookReader.csv", book, reader);

            int error = errorbook + errorread + errrorbookreader;

            Sketch.Mistake(error, bookreader);
        }
    }
}