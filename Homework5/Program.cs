using Homework5;
class Start
{
    public static void Main(string[] args)
    {
        /////////////////////////////
        Console.WriteLine("Упражнение 6.1 Написать программу, которая вычисляет число гласных и согласных букв в\r\nфайле. Имя файла передавать как аргумент в функцию Main. Содержимое текстового файла\r\nзаносится в массив символов. Количество гласных и согласных букв определяется проходом\r\nпо массиву. Предусмотреть метод, входным параметром которого является массив\r\nсимволов. Метод вычисляет количество гласных и согласных букв.\n");
        if (File.Exists(args[0]))
        {
            string stringChars = File.ReadAllText(args[0]);

            char[] chars = stringChars.ToCharArray();

            CalculateVowelsAndConsonants(chars);

        }
        else
        {
            Console.WriteLine("Не можем найти файл!");
        }
        /////////////////////////////

        /////////////////////////////
        Console.WriteLine("\nУпражнение 6.2 Написать программу, реализующую умножению двух матриц, заданных\r\nв виде двумерного массива. В программе предусмотреть два метода: метод печати\r\nматрицы, метод умножения матриц (на вход две матрицы, возвращаемое значение –\r\nматрица).\n");
        Matrix matrix = new Matrix();
        try
        {
            int[,] testMatrix = matrix.MultiplyMatrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } }, new int[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } });

            matrix.OutputMatrix(testMatrix);
        }
        catch (Exception e)
        {
            {
                Console.WriteLine($"Ошибка : {e.Message}");
            }
        }
        /////////////////////////////

        /////////////////////////////
        Console.WriteLine("\nУпражнение 6.3 Написать программу, вычисляющую среднюю температуру за год. Создать\r\nдвумерный рандомный массив temperature[12,30], в котором будет храниться температура\r\nдля каждого дня месяца (предполагается, что в каждом месяце 30 дней). Сгенерировать\r\nзначения температур случайным образом. Для каждого месяца распечатать среднюю\r\nтемпературу. Для этого написать метод, который по массиву temperature [12,30] для каждого\r\nмесяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив\r\nсредних температур. Полученный массив средних температур отсортировать по\r\nвозрастанию.\n");
        double[] averages = CalculateAverageTempereture();

        foreach (var value in averages)
        {
            Console.WriteLine(Math.Round(value, 2));
        }
        /////////////////////////////


        /////////////////////////////
        Console.WriteLine("\nДомашнее задание 6.1 Упражнение 6.1 выполнить с помощью коллекции List<T>.\n");

        if (File.Exists(args[0]))
        {
            // возьмем переменную stringChars ищ первого задания
            string stringChars = File.ReadAllText(args[0]);

            // создаем список
            List<string> listChars = new List<string>();
            listChars.Add(stringChars);

            // теперь преобразуем все символы stringChars в список символов
            List<char> chars = stringChars.ToList();

            CalculateVowelsAndConsonants(chars);

        }
        else
        {
            Console.WriteLine("Не можем найти файл!");
        }
        /////////////////////////////
        ///
        Console.WriteLine("\nДомашнее задание 6.3 Написать программу для упражнения 6.3, использовав класс\r\nDictionary<TKey, TValue>. В качестве ключей выбрать строки – названия месяцев, а в\r\nкачестве значений – массив значений температур по дням.\n");
        CalculateAverageTemperetureDictionary();
    }

    static void CalculateVowelsAndConsonants(char[] chars)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        int countVowels = 0;
        int countConsonants = 0;

        if (chars.Length == 0)
        {
            return;
        }

        foreach (char c in chars)
        {
            if (!Char.IsLetter(c)) { continue; }


            if (vowels.Contains(Char.ToLower(c)))
            {
                countVowels++;
            }
            else
            {
                countConsonants++;
            }
        }

        Console.WriteLine($"Согласных: {countConsonants}\nГласных: {countVowels}");
    }


    static void CalculateVowelsAndConsonants(List<char> chars)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        int countVowels = 0;
        int countConsonants = 0;

        foreach (char c in chars)
        {
            if (!Char.IsLetter(c)) { continue; }


            if (vowels.Contains(Char.ToLower(c)))
            {
                countVowels++;
            }
            else
            {
                countConsonants++;
            }
        }

        Console.WriteLine($"Согласных: {countConsonants}\nГласных: {countVowels}");
    }

    static double[] CalculateAverageTempereture()
    {

        Random random = new Random();
        int[,] temperatureArr = new int[12, 30];
        int months = temperatureArr.GetLength(0);
        int days = temperatureArr.GetLength(1);

        for (int i = 0; i < months; i++)
        {
            for (int j = 0; j < days; j++)
            {
                temperatureArr[i, j] = random.Next(-60, 60); // заполняем массив случайными значениями от -60 до 60
            }
        }

        double[] averages = new double[months];


        for (int i = 0; i < months; i++)
        {
            int sum = 0;
            for (int j = 0; j < days; j++)
            {
                sum += temperatureArr[i, j];
            }
            averages[i] = (double)sum / days;
        }
        Array.Sort(averages);
        return averages;
    }

    static void CalculateAverageTemperetureDictionary()
    {
        int days = 30;

        Dictionary<string, int[]> monthAndTemperature = new Dictionary<string, int[]>
        {
            { "Январь", InputRandomValues(days)},
            { "Февраль", InputRandomValues(days)},
            { "Март", InputRandomValues(days)},
            { "Апрель", InputRandomValues(days)},
            { "Май", InputRandomValues(days)},
            { "Июнь", InputRandomValues(days)},
            { "Июль", InputRandomValues(days)},
            { "Август", InputRandomValues(days)},
            { "Сентябрь", InputRandomValues(days)},
            { "Октябрь", InputRandomValues(days)},
            { "Ноябрь", InputRandomValues(days)},
            { "Декабрь", InputRandomValues(days)}
        };

        // словарь в котором будут храниться средние температуры и названия месяцев
        Dictionary<string, double> monthAverages = new Dictionary<string, double>();

        foreach (var val in monthAndTemperature)
        {
            int sum = 0;
            for (int i = 0; i < days; i++)
            {
                sum += val.Value[i];
            }

            double average = (double)sum / days;
            monthAverages[val.Key] = average;
        }

        foreach (var val in monthAverages)
        {
            Console.WriteLine($"{val.Key}: {Math.Round(val.Value, 2)}");
        }
    }

    static int[] InputRandomValues(int days) // заполняем массивы рандомными числами
    {
        Random random = new Random();
        int[] values = new int[days];

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = random.Next(-60, 60);
        }

        return values;
    }
}