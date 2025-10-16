
using AnotherTasks.Enums;

namespace AnotherTasks.Classes
{
    class StudentPM
    {
        public Guid Id { get; } // идентификатор студента
        public string LastName { get; set; } // фамилия 
        public string FirstName { get; set; } // имя
        public DateTime Birthday { get; } // дата рождения
        public int Scores { get; } // баллы которые набрал студент
        public List<ExamsForPM> ExamsForPM { get; } // экзамены для поступления на ПМ (прикладная математика)

        public StudentPM (string lastName, string firstName, DateTime birthday, List<ExamsForPM> examsForPM, int scores)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            ExamsForPM = examsForPM;
            Scores = scores;
        }

    }
}
