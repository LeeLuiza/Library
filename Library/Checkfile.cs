using System.Text;

namespace Laba1
{
    public class Checkfile
    {
        public static int GetBooks(string path)
        {
            string[] uncheckedData = File.ReadAllLines(path); //построчно записывается в массив
            int error = 0;
            for (int i = 1; i < uncheckedData.Length; i++)
            {
                int correctness = GetInformationCorrectnessBookData(uncheckedData[i].Split(';'), i); // проверка данных которых разделили по ;
                error += correctness;
            }
            return error;
        }


        public static int GetReaders(string path) //построчно записывается в массив
        {
            string[] uncheckedData = File.ReadAllLines(path); //построчно записывается в массив
            int error = 0;
            for (int i = 1; i < uncheckedData.Length; i++)
            {
                int correctness = GetInformationCorrectnessReaderData(uncheckedData[i].Split(';'), i); // проверка данных которых разделили по ;
                error += correctness;
            }
            return error;
        }


        public static int GetBookReaders(string path)
        {
            string[] uncheckedData = File.ReadAllLines(path);

            int error = 0;
            for (int i = 1; i < uncheckedData.Length; i++)
            {
                int correctness = GetInformationCorrectnessBookReaderData(uncheckedData[i].Split(';'), i);
                error += correctness;
            }
            return error;
        }

        public static int GetInformationCorrectnessBookData(string[] line, int row)
        {
            if (line.Length != 6)
            {
                Console.WriteLine($"Количество столбцов не совпадает с необходимым количеством в {row} строке");
                return 1;
            }
            else
            {
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
                    StringBuilder result = new();
                    result.Append("Данные не соответствуют требуемому формату в: ");

                    for (int i = 0; i < wrongColumns.Count; i++)
                    {
                        if (i == wrongColumns.Count - 1)
                        {
                            result.Append((wrongColumns[i] + 1).ToString());
                        }
                        else
                        {
                            result.Append((wrongColumns[i] + 1).ToString() + ", "); //последняя строчка
                        }
                    }

                    result.Append(" столбцах(-це).");
                    Console.WriteLine(result);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
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
                    StringBuilder result = new();
                    result.Append("Данные не соответствуют требуемому формату в: ");

                    for (int i = 0; i < wrongColumns.Count; i++)
                    {
                        if (i == wrongColumns.Count - 1)
                        {
                            result.Append(wrongColumns[i]);
                        }
                        else
                        {
                            result.Append(wrongColumns[i] + ", ");
                        }
                    }

                    result.Append(" столбцах(-це).");
                    Console.WriteLine(result);

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static int GetInformationCorrectnessBookReaderData(string[] line, int row)
        {
            if (line.Length < 3 || line.Length > 4)
            {
                Console.WriteLine($"Количество столбцов не совпадает с необходимым количеством в {row} строке");
                return 1;
            }
            else
            {
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
                    StringBuilder result = new();

                    result.Append("Данные не соответствуют требуемому формату в: ");
                    for (int i = 0; i < wrongColumns.Count; i++)
                    {
                        if (i == wrongColumns.Count - 1)
                        {
                            result.Append(wrongColumns[i] + 1);
                        }
                        else
                        {
                            result.Append(wrongColumns[i] + 1 + ", ");
                        }
                    }

                    result.Append(" столбцах(-це).");
                    Console.WriteLine(result);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}