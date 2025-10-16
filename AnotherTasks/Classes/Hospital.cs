namespace AnotherTasks.Classes
{
    class Hospital
    {
        public string Name { get; } // название больницы
        public List<string> TreatmentDiseases { get; } // список болезней которые лечат в больницк
        public ushort Capacity { get; } // вместимость
        public List<Grandmother> Patients { get; } // пациенты на данный момент

        public Hospital(string name, ushort capacity, List<string> treatmentDiseases, List<Grandmother> patients)
        {
            Name = name; 
            Capacity = capacity;
            TreatmentDiseases = treatmentDiseases;
            Patients = patients;
        }

        public bool TryAddGrandmother(Grandmother grandmother) // пробуем закинуть бабушку в больницу
        {
            if (Patients.Count >= Capacity)
            {
                return false; // больница переполнена
            }

            if (grandmother.Diseases.Count == 0)
            {
                Patients.Add(grandmother);
                Console.WriteLine("Бабушка пошла спрашивать");
                return true;
            }

            int treatedCount = 0;

            for (int i = 0; i < grandmother.Diseases.Count; i++)
            {
                string disease = grandmother.Diseases[i];
                if (TreatmentDiseases.Contains(disease))
                {
                    treatedCount++;
                }
            }

            double percent = (double)treatedCount / grandmother.Diseases.Count;

            if (percent > 0.5)
            {
                Patients.Add(grandmother);
                return true;
            }

            return false;
        }

        public void OutputInfo()
        {
            Console.WriteLine($"Больница: {Name}\nВместимость: {Capacity}\nЛечат болезни: {string.Join(", ", TreatmentDiseases)}\nПациенты: {Patients.Count}\nПроцент заполненности: {Math.Round((double)Patients.Count / Capacity * 100, 1)}%\n");

            if (Patients.Count != 0)
            {
                Console.Write("Пациенты: ");
                for (int i = 0; i < Patients.Count; i++)
                {
                    Console.Write(Patients[i].Name);
                    if (i < Patients.Count - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
