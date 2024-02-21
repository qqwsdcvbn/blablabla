using System;
using System.Collections.Generic;


class University
{
    public string first_name = "Илья"; // { get; }
    public string last_name = "Пузырь";
    public string age = "07.112005";
    public char sex = 'M';
    public List<int> assessment = new List<int>();
    //public record Student(string Age, string Sex, List<int> Assessment);
    //public Dictionary<string, Student> students { get; } = new()
    //{
    //    ["Илья Пузырев"] = new("07.11.2005", "M", new() { 4 })
    //};

    //public University()
    //{
    //    first_name = ;
    //    last_name = ;
    //    age = ;
    //    sex = ;
    //}

    public void Add(int num)
    {
        if (num >= 2 && num <= 5)
        {
            assessment.Add(num);
            Console.WriteLine("Оценка добавлена\n");
        }
        else
        {
            Console.WriteLine("Необходимо ввести оценку от 2 до 5\n");
        }
    }
//helloo

    public void Del(int num)
    {
        if (num >= 2 && num <= 5000)
        {
            if (!assessment.Remove(num))
            {
                Console.WriteLine("Такой оценки нет\n");
            } else
            {
                Console.WriteLine("Оценка удалена\n");
            }
        }
        else
        {
            Console.WriteLine("Необходимо ввести оценку от 2 до 5\n");
        }
    }

    public void GetEstimation()
    {
        if (assessment.Any())
        {
            Console.WriteLine($"Текущие оценки ученика {first_name} {last_name} - {string.Join(", ", assessment)}" +
                $"\nСредний балл - {assessment.Average()}\n");
        }
        else
        {
            Console.WriteLine($"У студента {first_name} {last_name} нет оценок\n");
        }
    }

    //private bool IsValid(int num)
    //{
    //    return num >= 2 && num <= 5;
    //}
}

class MedUniversity : University
{

    public void Compare()
    {
        if (assessment.Any())
        {
            double skills = assessment.Average();
            string message = skills switch
            {
                < 3 => "Этот студент плохо знает практику, лучше не допускать его к пациентам\n",
                < 3.8 => "Этот студент сгодится только помощником помощника\n",
                <= 4.4 => "Этот студент хорошо знает практику, но медецинский нож лучше не выдавать ему\n",
                > 4.4 => "Отличный студент, у него хорошие навыки\n"
            };
            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine($"У студента {first_name} {last_name} нет оценок за практику\n");
        }
    }
}


class Program
{

    static void Main()
    {
        MedUniversity uni = new MedUniversity();

        while (true)
        {
            try
            {
                Console.WriteLine("Выберите команду: \n1. Добавить оценку\n2. Убрать оценку\n3. Посмотреть оценки\n4. Проверить мед. навыки\n5. Выйти\n");
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        Console.WriteLine("\nВведите оценку для добавления:");
                        uni.Add(int.Parse(Console.ReadLine()));
                        break;

                    case 2:
                        Console.WriteLine("\nВведите оценку для удаления:");
                        uni.Del(int.Parse(Console.ReadLine()));
                        break;

                    case 3:
                        uni.GetEstimation();
                        break;

                    case 4:
                        uni.Compare();
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Некорректная команда. Пожалуйста, выберите снова.\n");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Должно быть целое число\n");
            }
        }
    }
}