namespace AnotherTasks.Classes
{
    class Grandmother
    {
        public string Name { get; } // имя бабушки
        public DateTime Birthday { get; } // дата рождения 
        public List<string> Diseases { get; } // болезни
        public List<string> Medicines { get; } // лекарства

        public Grandmother(string name, DateTime birthday,  List<string> diseases, List<string> medicines)
        {
            Name = name;
            Birthday = birthday;
            Diseases = diseases;
            Medicines = medicines;
        }

        public void PlakiPlaki()
        {
            Console.WriteLine("Бабуля плачет!");
        }

        public void OutputInfo()
        {
            int age = DateTime.Now.Year - Birthday.Year;
            Console.WriteLine("Имя: " + Name);
            Console.WriteLine("Возраст: " + age);

            if (Diseases.Count > 0)
            {
                Console.WriteLine("Болезни: " + string.Join(", ", Diseases));
            }

            if (Medicines.Count > 0)
            {
                Console.WriteLine("Лекарства: " + string.Join(", ", Medicines));
            }

            Console.WriteLine();
        }
    }
}
