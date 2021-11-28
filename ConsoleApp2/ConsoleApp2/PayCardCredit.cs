using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Карта кредитная - класс из ЛР №5 */

public class PayCardCredit : PayCard
{

    public int CreditAmount; // сумма кредита (овердрафта) в у.е.

    public PayCardCredit() : base() // конструктор
    {
        CreditAmount = 700; // кредит в 700у.е. в эквиваленте доступен по умолчанию всем держателям

    }

    public PayCardCredit(string CNum, string Pin, int CredAmt) : base(CNum, Pin) // конструктор
    {
        CreditAmount = CredAmt;

    }

    public new void GetInfo()
    {
        /* вывод информации о кредитной карте на консоль */

        Console.WriteLine("Платежная кредитная карта : номер {0} пин в зашифрованном виде {1} доступно кредитных средств - {2} у.е.", CardNumber, PinCodeEncrypted, CreditAmount);

    }

    new public string ToString()
    {

        /* выводит информацию о типе объекта и его текущих значениях */

        string objinfo = "Кредитная платежная карта : номер " + CardNumber + " пин в зашифрованном виде " + PinCodeEncrypted + " доступно кредитных средств - " + CreditAmount.ToString() + " у.е.";

        return objinfo;

    }
}