using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class AccountEventArgs3
    {

        
        public string Message { get; }      // Сообщение
       
        public int Sum { get; }          // Сумма, на которую изменился счет

        public AccountEventArgs3(string mes, int sum)
        {
            Message = mes;
            Sum = sum;
        }

    }
}
