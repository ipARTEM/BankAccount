using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Account
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;              // 1.Определение события

        public Account(int sum)
        {
            Sum = sum;
        }
        // сумма на счете
        public int Sum { get; private set; }
        // добавление средств на счет
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"На счет поступило: {sum}");   // 2.Вызов события 
        }
        // списание средств со счета
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счета снято: {sum}");   // 2.Вызов события
            }
            else
            {
                Notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}"); ;
            }
        }

       

    }

    //****************************************************************************************************************

    class Account2
    {
        public delegate void AccountHandler2(string message);
        private event AccountHandler2 _notify2;
        public event AccountHandler2 Notify2
        {
            add
            {
                _notify2 += value;
                Console.WriteLine($"{value.Method.Name} добавлен");
            }
            remove
            {
                _notify2 -= value;
                Console.WriteLine($"{value.Method.Name} удален");
            }
        }
        public Account2(int sum2)
        {
            Sum2 = sum2;
        }
        public int Sum2 { get; private set; }
        public void Put2(int sum2)
        {
            Sum2 += sum2;
            _notify2?.Invoke($"На счет поступило: {sum2}");
        }

        public void Take2(int sum2)
        {
            if (Sum2 >= sum2)
            {
                Sum2 -= sum2;
                _notify2?.Invoke($"Со счета снято: {sum2}");
            }
            else
            {
                _notify2?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum2}"); ;
            }
        }
    }

    //****************************************************************************************************************


    class Account3
    {
        public delegate void AccountHandler3(object sender, AccountEventArgs3 e);
        public event AccountHandler3 Notify3;
        public Account3(int sum3)
        {
            Sum3 = sum3;
        }
        public int Sum3 { get; private set; }
        public void Put3(int sum3)
        {
            Sum3 += sum3;
            Notify3?.Invoke(this, new AccountEventArgs3($"На счет поступило {sum3}", sum3));
        }
        public void Take3(int sum3)
        {
            if (Sum3 >= sum3)
            {
                Sum3 -= sum3;
                Notify3?.Invoke(this, new AccountEventArgs3($"Сумма {sum3} снята со счета", sum3));
            }
            else
            {
                Notify3?.Invoke(this, new AccountEventArgs3("Недостаточно денег на счете", sum3)); ;
            }
        }
    }

}
