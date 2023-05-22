namespace ConsoleAppdz_15
{
    internal class Program
    {
        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        static int Fibonacci(int n)
        {
            if (n <= 1)
                return n;

            int a = 0;
            int b = 1;

            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }

            return b;
        }

        static int CountReplacements(string content, string searchWord, string replaceWord)
        {
            int count = 0;
            int index = content.IndexOf(searchWord);
            while (index != -1)
            {
                count++;
                index = content.IndexOf(searchWord, index + searchWord.Length);
            }
            return count;
        }

        static string ReverseString(string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void Main(string[] args)
        {
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Random random = new Random();
                    List<int> numbers = new List<int>();
                    for (int i = 0; i < 100; i++)
                    {
                        int number = random.Next(1, 1000);
                        numbers.Add(number);
                    }

                    List<int> primes = new List<int>();
                    foreach (int number in numbers)
                    {
                        if (IsPrime(number))
                            primes.Add(number);
                    }
                    File.WriteAllLines("primes.txt", primes.Select(x => x.ToString()));

                    List<int> fibonaccis = new List<int>();
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int fibonacciNumber = Fibonacci(i);
                        if (fibonacciNumber > 1000)
                            break;

                        fibonaccis.Add(fibonacciNumber);
                    }
                    File.WriteAllLines("fibonacci.txt", fibonaccis.Select(x => x.ToString()));
                    Console.WriteLine($"Згенеровано {numbers.Count} чисел.");
                    Console.WriteLine($"Записано {primes.Count} простих чисел у файл primes.txt.");
                    Console.WriteLine($"Записано {fibonaccis.Count} чисел Фібоначчі у файл fibonacci.txt.");
                    break;
                    case 2:
                    Console.WriteLine("Введіть шукане слово:");
                    string searchWord = Console.ReadLine();

                    Console.WriteLine("Введіть слово для заміни:");
                    string replaceWord = Console.ReadLine();

                    string fileName = "D:\\visualST\\ConsoleAppdz_15\\ConsoleAppdz_15\\input.txt";                   
                        string fileContent = File.ReadAllText(fileName);
                        string modifiedContent = fileContent.Replace(searchWord, replaceWord);
                        File.WriteAllText(fileName, modifiedContent);
                        int replacementsCount = CountReplacements(fileContent, searchWord, replaceWord);                      
                        Console.WriteLine($"Знайдено та замінено {replacementsCount} входжень слова \"{searchWord}\" на \"{replaceWord}\".");
                        break;
                    case 3:                   
                    string textFilePath = "D:\\visualST\\ConsoleAppdz_15\\ConsoleAppdz_15\\textFilePath.txt";                   
                    string moderationFilePath = "D:\\visualST\\ConsoleAppdz_15\\ConsoleAppdz_15\\moderationFilePath.txt";                 
                    string[] moderationWords = File.ReadAllLines(moderationFilePath);
                    string text = File.ReadAllText(textFilePath);

                        foreach (string word in moderationWords)
                        {
                            string moderatedWord = new string('*', word.Length);
                            text = text.Replace(word, moderatedWord);
                        }
                        File.WriteAllText(textFilePath, text);                                           
                    break;
                    case 4:
                    Console.WriteLine("Введіть шлях до файлу:");
                    string filePath = Console.ReadLine();

                   
                        string file = File.ReadAllText(filePath);
                        string reversedContent = ReverseString(file);

                        string reversedFilePath = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + "_reversed" + Path.GetExtension(filePath);
                        File.WriteAllText(reversedFilePath, reversedContent);

                        Console.WriteLine("Готово.");
                        break;
                    case 5:
                    string File_path = "D:\\visualST\\ConsoleAppdz_15\\ConsoleAppdz_15\\numbers.txt"; 
                    string positiveFilePath = "D:\\visualST\\ConsoleAppdz_15\\ConsoleAppdz_15\\positive_numbers.txt"; 
                    string negativeFilePath = "D:\\visualST\\ConsoleAppdz_15\\ConsoleAppdz_15\\negative_numbers.txt"; 
                    string twoDigitFilePath = "D:\\visualST\\ConsoleAppdz_15\\ConsoleAppdz_15\\two_digit_numbers.txt"; 
                    string fiveDigitFilePath = "D:\\visualST\\ConsoleAppdz_15\\ConsoleAppdz_15\\five_digit_numbers.txt"; 

                    
                        int positiveCount = 0;
                        int negativeCount = 0;
                        int twoDigitCount = 0;
                        int fiveDigitCount = 0;

                        using (StreamReader reader = new StreamReader(File_path))
                        {
                            using (StreamWriter positiveWriter = new StreamWriter(positiveFilePath))
                            using (StreamWriter negativeWriter = new StreamWriter(negativeFilePath))
                            using (StreamWriter twoDigitWriter = new StreamWriter(twoDigitFilePath))
                            using (StreamWriter fiveDigitWriter = new StreamWriter(fiveDigitFilePath))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    int number = int.Parse(line);                                  
                                    if (number > 0)
                                    {
                                        positiveCount++;
                                        positiveWriter.WriteLine(number);
                                    }
                                    else if (number < 0)
                                    {
                                        negativeCount++;
                                        negativeWriter.WriteLine(number);
                                    }

                                    if (number >= 10 && number <= 99)
                                    {
                                        twoDigitCount++;
                                        twoDigitWriter.WriteLine(number);
                                    }

                                    if (number >= 10000 && number <= 99999)
                                    {
                                        fiveDigitCount++;
                                        fiveDigitWriter.WriteLine(number);
                                    }
                                }
                            }
                        }

                        Console.WriteLine($"Кількість додатних чисел: {positiveCount}");
                        Console.WriteLine($"Кількість від'ємних чисел: {negativeCount}");
                        Console.WriteLine($"Кількість двозначних чисел: {twoDigitCount}");
                        Console.WriteLine($"Кількість п'ятизначних чисел: {fiveDigitCount}");
                        break; 
            }
        }
    }
}