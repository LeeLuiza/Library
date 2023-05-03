using System.Reflection.PortableExecutable;
using System.Text;

namespace Laba1
{
    public class Checkfile
    {
        public static Book[] GetBooks(string path)

        {
            string[] uncheckedData = File.ReadAllLines(path); //построчно записывается в массив
            List<string> correctline = new List<string>();
            for (int i = 1; i < uncheckedData.Length; i++)
            {
                int correctness = GetInformationCorrectnessBookData(uncheckedData[i].Split(';'), i); // проверка данных которых разделили по ;
                if (correctness == 0) correctline.Add(uncheckedData[i]);
            }
            Book[] book = Dataentry.Book(correctline);
            return book;
        }


        public static Reader[] GetReaders(string path) //построчно записывается в массив
        {
            string[] uncheckedData = File.ReadAllLines(path); //построчно записывается в массив
            List<string> correctline = new List<string>();
            for (int i = 1; i < uncheckedData.Length; i++)
            {
                int correctness = GetInformationCorrectnessReaderData(uncheckedData[i].Split(';'), i);
                if (correctness == 0) correctline.Add(uncheckedData[i]);
            }
            Reader[] reader = Dataentry.Reader(correctline);
            return reader;
        }


        public static BookReader[] GetBookReaders(string path, Book[] book, Reader[] reader)
        {
            string[] uncheckedData = File.ReadAllLines(path);
            List<string> correctline = new List<string>();
            for (int i = 1; i < uncheckedData.Length; i++)
            {
                int correctness = GetInformationCorrectnessBookReaderData(uncheckedData[i].Split(';'), i);
                if (correctness == 0) correctline.Add(uncheckedData[i]);
            }
            BookReader[] bookreader = Dataentry.BookReaders(correctline, book, reader);
            return bookreader;
        }

        public static int GetInformationCorrectnessBookData(string[] line, int row)
        {
            if (line.Length != 6)
            {
                Console.WriteLine($"Количество столбцов не совпадает с необходимым количеством в {row} строке");
                return 1;
            }
            
            List<int> wrongColumns = new();

            if (!int.TryParse(line[0], out _))
            {
                wrongColumns.Add(0);
            }

            for (int i = 1; i < 3; i++)
            {
                if (line[i] == "")
                {
                    wrongColumns.Add(i);
                }
            }

            for (int i = 3; i < line.Length; i++)
            {
                if (!int.TryParse(line[i], out _))
                {
                    wrongColumns.Add(i);
                }
            }

            if (wrongColumns.Count != 0)
            {
                Console.WriteLine($"Данные не соответствуют требуемому формату в {row} строке: ");
                Console.Write(wrongColumns[0] + 1);
                for (int i = 1; i < wrongColumns.Count; i++)
                {
                    Console.Write(", ");
                    Console.Write(wrongColumns[i] + 1);
                }

                Console.Write(" столбцах(-це).");
                return 1;
            }
            return 0;
        }

        public static int GetInformationCorrectnessReaderData(string[] line, int row)
        {
            if (line.Length != 2)
            {
                Console.WriteLine($"Количество столбцов не совпадает с необходимым количеством в {row} строке");
                return 1;
            }
            else
            {
                List<int> wrongColumns = new();

                if (!int.TryParse(line[0], out _))
                {
                    wrongColumns.Add(1);
                }

                if (line[1] == "")
                {
                    wrongColumns.Add(2);
                }

                if (wrongColumns.Count > 0)
                {
                    Console.WriteLine($"Данные не соответствуют требуемому формату в {row} строке: ");
                    Console.Write(wrongColumns[0] + 1);
                    for (int i = 1; i < wrongColumns.Count; i++)
                    {
                        Console.Write(", ");
                        Console.Write(wrongColumns[i] + 1);
                    }

                    Console.Write(" столбцах(-це).");
                    return 1;
                }
                return 0;
            }
        }

        public static int GetInformationCorrectnessBookReaderData(string[] line, int row)
        {
            if (line.Length < 3 || line.Length > 4)
            {
                Console.WriteLine($"Количество столбцов не совпадает с необходимым количеством в {row} строке");
                return 1;
            }
            List<int> wrongColumns = new();

            for (int i = 0; i < 2; i++)
            {
                if (!int.TryParse(line[i], out _))
                {
                    wrongColumns.Add(i);
                }
            }

            for (int i = 2; i < line.Length; i++)
            {
                if (!DateTime.TryParse(line[i], out _))
                {
                    wrongColumns.Add(i);
                }
            }

            if (wrongColumns.Count > 0)
            {
                Console.WriteLine($"Данные не соответствуют требуемому формату в {row} строке: ");
                Console.Write(wrongColumns[0] + 1);
                for (int i = 1; i < wrongColumns.Count; i++)
                {
                    Console.Write(", ");
                    Console.Write(wrongColumns[i] + 1);
                }

                Console.Write(" столбцах(-це).");
                return 1;
            }
            return 0;
        }
    }
}