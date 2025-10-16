using AnotherTasks.Classes;
using AnotherTasks.Enums;
using System.Xml.Linq;

class Start
{
    public static void Main(string[] args)
    {
        //////////////////////////////
        Console.WriteLine("Задание 1. Создать List на 64 элемента, скачать из интернета 32 пары картинок (любых). В List\r\nдолжно содержаться по 2 одинаковых картинки. Необходимо перемешать List с\r\nкартинками. Вывести в консоль перемешанные номера (изначальный List и\r\nполученный List). Перемешать любым способом.\n");
        try
        {
            OutputMixedImgs();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        //////////////////////////////

        //////////////////////////////
        Console.WriteLine("\nЗадание 2. Создать студента из вашей группы (фамилия, имя, год рождения, с каким\r\nэкзаменом поступил, баллы). Создать словарь для студентов из вашей группы (10\r\nчеловек).\r\nНеобходимо прочитать информацию о студентах с файла. В консоли необходимо создать\r\nменю:\r\na. Если пользователь вводит: Новый студент, то необходимо\r\nввести информацию о новом студенте и добавить его в List\r\nb. Если пользователь вводит: Удалить, то по фамилии и имени удаляется\r\nстудент\r\nc. Если пользователь вводит: Сортировать, то происходит сортировка по\r\nбаллам (по возрастанию)\n");


        string filePath = "studentsPM.txt";  // путь к файлу со студентами

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Файл Students не найден!");
        }

        Dictionary<Guid, StudentPM> students = CreateStudents(filePath);        

        foreach (var student in students)
        {
            Console.WriteLine($"Индентификатор({student.Key}): {student.Value.FirstName}, {student.Value.LastName}, {student.Value.Birthday}, {OutputSubject(student.Value.ExamsForPM)}, {student.Value.Scores}");
        }
        //////////////////////////////
    }

    static void OutputMixedImgs()
    {
        List<string> listNameOfImgs = new List<string>(); // список для хранения названий файлов
        string folderPath = "../../../Images"; // путь к папке с котиками

        if (!Directory.Exists(folderPath))
        {
            throw new DirectoryNotFoundException("Папка Images не найдена!");
        }

        string[] files = Directory.GetFiles(folderPath); // получаем файлы из папки


        for (int i = 0; i < files.Length; i++)
        {
            listNameOfImgs.Add(Path.GetFileName(files[i])); // добавляем по 2 названия одного и то же файла
            listNameOfImgs.Add(Path.GetFileName(files[i]));
        }

        foreach (string file in listNameOfImgs)
        {
            Console.WriteLine(file); // выводим список до перестановок
        }


        Random random = new Random();
        for (int i = listNameOfImgs.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1); // случайный индекс от 0 до i

            string temp = listNameOfImgs[i];
            listNameOfImgs[i] = listNameOfImgs[j]; // меняем элементы местами, через временную переменную
            listNameOfImgs[j] = temp;
        }

        Console.WriteLine("\nНовый список:");
        foreach (string file in listNameOfImgs)
        {
            Console.WriteLine(file);
        }

    }


    static Dictionary<Guid, StudentPM> CreateStudents(string filePath)
    {
        Dictionary<Guid, StudentPM> students = new Dictionary<Guid, StudentPM>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return students;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            try
            {
                // Архипов;Кирилл;2006-12-15;МатематикаПрофиль,Информатика,Русский;270
                string[] parts = line.Split(';');
                string lastName = parts[0];
                string firstName = parts[1];
                DateTime birthday = DateTime.Parse(parts[2]);

                string examsString = parts[3];
                string[] examNames = examsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

                List<ExamsForPM> exams = new List<ExamsForPM>();

                foreach (string name in examNames)
                {
                    // Преобразуем текст в элемент перечисления ExamsForPM
                    ExamsForPM exam = Enum.Parse<ExamsForPM>(name.Trim());

                    exams.Add(exam);
                }

                int scores = int.Parse(parts[4]);

                StudentPM student = new StudentPM(lastName, firstName, birthday, exams, scores);
                students.Add(student.Id, student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке строки: {line}");
                Console.WriteLine(ex.Message);
            }
        }

        bool isContinue = true;

        while (isContinue)
        {
            Console.Write("Введите команду(новый студент, удалить, сортировать, выход):");
            string text = Console.ReadLine().ToLower();

            switch (text)
            {
                case "новый студент":
                    AddStudent(students);
                    break;

                case "удалить":
                    DeleteStudent(students);
                    break;

                case "сортировать":
                    SortStudentsByScore(students);
                    break;

                case "выход":
                    isContinue = false;
                    break;

                default:
                    Console.WriteLine("Команда не распознана!");
                    break;
            }
        }

        return students;
    }

    static string OutputSubject(List<ExamsForPM> examsForPM)
    {
        string subjects = string.Empty;
        foreach (var subj in examsForPM)
        {
            subjects += subj;
            subjects += " ";
        }

        return subjects;
    }

    static void AddStudent(Dictionary<Guid, StudentPM> students)
    {
        Console.Write("Введите имя студента: ");
        string firstName = Console.ReadLine();

        Console.Write("Введите фамилию студента: ");
        string lastName = Console.ReadLine();

        Console.Write("Введите дату рождения(в формате 2000.02.15): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthday))
        {
            throw new FormatException("Дата введена неправильно!");
        }

        Console.Write("Введите число предметов(максимум 4): ");
        List<ExamsForPM> exams = new List<ExamsForPM>();

        if (int.TryParse(Console.ReadLine(), out int value))
        {
            if (value < 1 || value > 4)
            {
                Console.WriteLine("Некорректное кол-во предметов");
            }
            else
            {
                for (int i = 0; i < value; i++)
                {
                    exams.Add(Enum.Parse<ExamsForPM>(Console.ReadLine().Trim()));
                }
            }
        }

        Console.Write("Введите количество баллов: ");
        if (!int.TryParse(Console.ReadLine(), out int scores))
        {
            throw new FormatException("Число баллов некорректное");
        }

        StudentPM student = new StudentPM(lastName, firstName, birthday, exams, scores);

        students.Add(student.Id, student);
        Console.WriteLine("Студент успешно добавлен!");
    }

    static void DeleteStudent(Dictionary<Guid, StudentPM> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Список студентов пуст!");
            return;
        }

        Console.Write("Введите фамилию студента: ");
        string lastName = Console.ReadLine();

        Console.Write("Введите имя студента: ");
        string firstName = Console.ReadLine();

        foreach (var pair in students)
        {
            var s = pair.Value;
            if (s.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
            {
                students.Remove(pair.Key);
                Console.WriteLine($"Студент {lastName} {firstName} удалён!");
                return;
            }
        }

        Console.WriteLine("Такой студент не найден.");
    }

    static void SortStudentsByScore(Dictionary<Guid, StudentPM> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Список студентов пуст!");
            return;
        }

        // Переносим студентов в список для удобствао
        List<StudentPM> list = new List<StudentPM>();

        foreach (var s in students.Values)
        {
            list.Add(s);
        }

        // Сортируем по баллам по возрастанию
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[i].Scores > list[j].Scores)
                {
                    var temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }

        Console.WriteLine("\nСтуденты по возрастанию баллов:\n");

        foreach (var student in list)
        {
            Console.WriteLine($"{student.LastName} {student.FirstName}: {student.Scores}");
        }
    }
}