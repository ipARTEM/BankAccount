using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Program
    {
       


        static void Main(string[] args)
        {
            Account acc = new Account(100);     // установка делегата, который указывает на метод DisplayMessage

            acc.Notify += DisplayMessage;   // Добавляем обработчик для события Notify

            acc.Notify += DisplayRedMessage;    // добавляем обработчик DisplayMessage
            //acc.Notify += new ActionHandler(DisplayMessage);    // установка в качестве обработчика метода DisplayMessage // что-то не работает!

            acc.Put(20);    // добавляем на счет 20
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(70);   // пытаемся снять со счета 70
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(180);  // пытаемся снять со счета 180
            Console.WriteLine($"Сумма на счете: {acc.Sum}");

            acc.Notify -= DisplayRedMessage;     // удаляем обработчик DisplayRedMessage
            acc.Take(15);  // пытаемся снять со счета 15
            Console.WriteLine($"Сумма на счете: {acc.Sum}");

            acc.Notify += delegate (string mes)     //Установка в качестве обработчика анонимного метода
            {
                Console.WriteLine(mes);
            };
            
            acc.Notify += mes => Console.WriteLine(mes);        //Установка в качестве обработчика лямбда-выражения:
            acc.Put(55);

            Console.WriteLine("************************************************************************");

            Account2 acc2 = new Account2(100);
            acc2.Notify2 += DisplayMessage2;       // добавляем обработчик DisplayMessage
            acc2.Put2(20);    // добавляем на счет 20
            acc2.Notify2 -= DisplayMessage2;     // удаляем обработчик DisplayRedMessage
            acc2.Put2(20);    // добавляем на счет 20

            Console.WriteLine("************************************************************************");

            Account3 acc3 = new Account3(100);
            acc3.Notify3 += DisplayMessage3;
            acc3.Put3(20);
            acc3.Take3(70);
            acc3.Take3(150);

            Console.Read();
        }

        private static void DisplayMessage3(object sender, AccountEventArgs3 e)
        {
            Console.WriteLine($"Сумма транзакции: {e.Sum}");
            Console.WriteLine(e.Message);
            Console.WriteLine("Событие внутри DisplayMessage3");
           
        }


        private static void DisplayMessage2(string message) 
        {
            Console.WriteLine(message);

            Console.WriteLine("Событие внутри DisplayMessage2");
        } 


        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Событие внутри DisplayMessage");
        }

        private static void DisplayRedMessage(String message)
        {
            // Устанавливаем красный цвет символов
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            // Сбрасываем настройки цвета
            Console.ResetColor();
            Console.WriteLine("Событие внутри DisplayRedMessage");
        }

    }
}
