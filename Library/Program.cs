using System;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace Laba1
{
    public class Program
    {
        public static void Main()
        {
            Book[] book = Checkfile.GetBooks("Book.csv");
            Reader[] reader = Checkfile.GetReaders("Reader.csv");
            BookReader[] bookreader = Checkfile.GetBookReaders("BookReader.csv", book, reader);

            Sketch.Table(bookreader);
        }
    }
}