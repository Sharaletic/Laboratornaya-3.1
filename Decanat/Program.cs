using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace Decanat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Удалить студента");
            Console.WriteLine("3. Показать список студентов");
            Console.WriteLine("4. Вывести гистограмму: распределение студентов по специальностям");


            while (true)
            {
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());

                    switch (number)
                    {
                        case 1:
                            AddStudent(logic);
                            break;

                        case 2:
                            RemoveStudent(logic);
                            break;

                        case 3:
                            OutputStudents(logic);
                            break;

                        case 4:
                            SortStudents(logic);
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод\n");
                }
            }
        }

        private static int ParseInt(string number)
        {
            int cur = 0;
            try
            {
                cur = Convert.ToInt32(number);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return cur;
        }
        private static void SortStudents(Logic logic)
        {
            foreach (var item in logic.DistributionStudents())
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
            Console.WriteLine();
        }

        private static void OutputStudents(Logic logic)
        {
            for (int i = 0; i < logic.GetListStudents().Count; i++)
            {
                foreach (string s in logic.GetListStudents()[i])
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }
        }

        private static void RemoveStudent(Logic logic)
        {

            int index = 1;
            Console.WriteLine("Выберете номер студента, которого хотите удалить");
            for (int i = 0; i < logic.GetListStudents().Count; i++)
            {
                Console.WriteLine(index + ":");
                foreach (string s in logic.GetListStudents()[i])
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                index++;
            }
            int indexOfChange = int.Parse(Console.ReadLine());
            if (indexOfChange - 1 >= 0 && indexOfChange - 1 < logic.GetListStudents().Count)
            {
                logic.RemoveStudent(indexOfChange - 1);
                Console.WriteLine("Студент удален\n");
            }
            else
            {
                Console.WriteLine("Студент не удален\n");
            }
        }

        private static void AddStudent(Logic logic)
        {
            Console.WriteLine("Введите ФИО студента");
            string nameAdd = Console.ReadLine();
            Console.WriteLine("Введите специальность студента");
            string specialityAdd = Console.ReadLine();
            Console.WriteLine("Введите группу студента");
            string groupAdd = Console.ReadLine();
            if (nameAdd != string.Empty && specialityAdd != string.Empty && groupAdd != string.Empty)
            {
                logic.AddStudent(nameAdd, specialityAdd, groupAdd);
                Console.WriteLine("Студент добавлен\n");
            }
            if (nameAdd == string.Empty || specialityAdd == string.Empty || groupAdd == string.Empty)
            {
                Console.WriteLine("Заполните все поля\n");
            }
        }
    }
}