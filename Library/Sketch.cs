namespace Laba1
{
    public class Sketch
    {
        public static int Mistake(int error, BookReader[] bookreader)
        {
            DateTime date = new DateTime(2023, 4, 28);
            if (error == 0)
            {
                Table(bookreader);
            }
            return 0;
        }


        static void Table(BookReader[] bookreader)
        {
            int maxAuthor = 0;
            for (int i = 0; i < bookreader.Length; i++)
            {
                maxAuthor = Math.Max(maxAuthor, bookreader[i].Bookname.Author.Length);
            }
            int maxTitle = 0;
            for (int i = 0; i < bookreader.Length; i++)
            {
                maxTitle = Math.Max(maxTitle, bookreader[i].Bookname.Title.Length);
            }
            int maxReader = 0;
            for (int i = 0; i < bookreader.Length; i++)
            {
                maxReader = Math.Max(maxReader, bookreader[i].Readername.Name.Length);
            }
            int maxdata = 10;
            int maxx = maxAuthor + maxTitle + maxReader + maxdata + 8 + 8;

            for (int l = 0; l < maxx; l++) Console.Write("-");
            Console.WriteLine();

            Console.Write("|");
            Console.Write(" " + "Автор");
            for (int v = 0; v <= (maxAuthor - 5); v++) Console.Write(" ");
            Console.Write("|");

            Console.Write("|");
            Console.Write(" " + "Название");
            for (int v = 0; v <= (maxTitle - 8); v++) Console.Write(" ");
            Console.Write("|");

            Console.Write("|");
            Console.Write(" " + "Читает");
            for (int v = 0; v <= (maxReader - 6); v++) Console.Write(" ");
            Console.Write("|");

            Console.Write("|");
            Console.Write(" " + "Дата");
            for (int v = 0; v <= (maxdata - 4); v++) Console.Write(" ");
            Console.Write("|");

            Console.WriteLine();

            for (int i = 0; i < bookreader.Length; i++)
            {
                int column = 1;
                for (int l = 0; l < maxx; l++) Console.Write("-");
                Console.WriteLine();
                if (column == 1)
                {
                    Console.Write("|");
                    Console.Write(" " + bookreader[i].Bookname.Author);
                    for (int v = 0; v <= (maxAuthor - bookreader[i].Bookname.Author.Length); v++) Console.Write(" ");
                    Console.Write("|");
                    column++;
                }
                if (column == 2)
                {
                    Console.Write("|");
                    Console.Write(" " + bookreader[i].Bookname.Title);
                    for (int v = 0; v <= (maxTitle - bookreader[i].Bookname.Title.Length); v++) Console.Write(" ");
                    Console.Write("|");
                    column++;
                }
                if (column == 3)
                {
                    Console.Write("|");
                    Console.Write(" " + bookreader[i].Readername.Name);
                    for (int v = 0; v <= (maxReader - bookreader[i].Readername.Name.Length); v++) Console.Write(" ");
                    Console.Write("|");
                    column++;
                }
                if (column == 4)
                {
                    if (bookreader[i].Returndate > DateTime.Now)
                    {
                        Console.Write("|"); //DateOnly.FromDateTime(DateTime.Now);
                        Console.Write(" " + DateOnly.FromDateTime(bookreader[i].Takedate));
                        Console.Write(" ");
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write("| ");
                        for (int v = 0; v <= maxdata; v++) Console.Write(" ");
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
            }
            for (int l = 0; l < maxx; l++) Console.Write("-");
            Console.WriteLine();
        }
    }
}