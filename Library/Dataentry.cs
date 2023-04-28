﻿namespace Laba1
{
    public class Dataentry
    {
        public static Book[] Book(string path)
        {
            string[] databook = File.ReadAllLines(path);
            Book[] book = new Book[databook.Length - 1];
            for (int i = 0; i < databook.Length - 1; i++)
            {
                string[] lineData = databook[i + 1].Split(';');
                book[i] = new Book(
                    int.Parse(lineData[0]), //первый столбец в файле книг парсим в инт
                    lineData[1], // тип стринг
                    lineData[2],
                    int.Parse(lineData[3]),
                    int.Parse(lineData[4]),
                    int.Parse(lineData[5]));

            }
            return book;
        }


        public static Reader[] Reader(string path)
        {
            string[] datareader = File.ReadAllLines(path);
            Reader[] reader = new Reader[datareader.Length - 1];
            for (int i = 0; i < datareader.Length - 1; i++)
            {
                string[] lineData = datareader[i + 1].Split(';');
                reader[i] = new Reader(
                    int.Parse(lineData[0]), //первый столбец в файле книг парсим в инт
                lineData[1]);
            }
            return reader;
        }


        public static BookReader[] BookReaders(string path, Book[] book, Reader[] reader)
        {
            string[] databookreaders = File.ReadAllLines(path);

            BookReader[] bookreader = new BookReader[databookreaders.Length - 1];
            for (int i = 0; i < databookreaders.Length - 1; i++)
            {
                string[] lineData = databookreaders[i + 1].Split(';');

                bookreader[i] = new BookReader(FindBook(book, int.Parse(lineData[0])),
                    FindReader(reader, int.Parse(lineData[1])), DateTime.Parse(lineData[2]), DateTime.Parse(lineData[3]));
            }
            return bookreader;
        }


        public static Reader FindReader(Reader[] reader, int id)
        {
            for (int i = 0; i < reader.Length; i++)
            {
                if (reader[i].ID == id)
                {
                    id = i;
                    break;
                }
            }
            return reader[id];
        }


        public static Book FindBook(Book[] book, int id)
        {
            for (int i = 0; i < book.Length; i++)
            {
                if (book[i].ID == id)
                {
                    id = i;
                    break;
                }
            }

            return book[id];
        }
    }
}