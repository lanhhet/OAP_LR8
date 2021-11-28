using System;
using System.IO; // поддержка работы с файлами
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // поддержка загрузки данных из Json файла

/* В ЛР №4 нашим классом являлась Очередь (вариант 22)
 Очередь - одномерная структура данных, для которой загрузка и извлечение элементов осуществляется
 с помощью указателей начала извлечения (head) и конца (tail) очереди в соответствии с правилом 
 FIFO ("FIFO" - "первым введен, первым выведен"), т. е. включение производится с одного, а исключение – с другого конца.

*/

interface IMYopers<T> // обобщенный интерфейc
{
    void Add(T varobj);     // добавить
    T Delete();             // удалить
    T View(int idx);        // просмотреть

}

public class CollectionType<T> : IMYopers<T> /* where T : class */
{
    // вкладываем обобщенную коллекцию - возьмем Queue<T> - класс очереди объектов, работающей по алгоритму FIFO("первый вошел-первый вышел")

    public Queue<T> TheCollection = null;

    public CollectionType() // конструктор
    {
        TheCollection = new Queue<T>();
    }

    public void Add(T varobj)
    {
        /* добавить объект в коллекцию */

        TheCollection.Enqueue(varobj); // Добавляет объект в конец коллекции Queue<T>

    }
    public T Delete()
    {
        /* удалить первый объект из коллекции и вернуть его */

        T ret_val = default(T); // инициализируем (default(T) означает, что если T - cсылочный тип, то присваивается null, а если тип значений - значение 0)

        ret_val = TheCollection.Dequeue(); // удаляет объект из начала коллекции Queue<T> и возвращает его

        return ret_val;

    }

    public T View(int varidx)
    {
        /* просмотреть (выведем на консоль) объект коллекции по его индексу (0-based),
           возвращает данный объект
         */

        T ret_val = default(T); // инициализируем (default(T) означает, что если T - cсылочный тип, то присваивается null, а если тип значений - значение 0)

        try
        {

            ret_val = TheCollection.ElementAt(varidx); // возвращает элемент по указанному индексу, вызывает исключение, если индекс меньше 0 либо больше старшего имеющегося

            // выведем на консоль - просмотр

            // если это платежная карта
            if ((ret_val as PayCardCredit) != null) Console.WriteLine("Значение объекта : {0}", (ret_val as PayCardCredit).ToString());
            else
            Console.WriteLine("Значение объекта : {0}", ret_val.ToString());


        }
        catch (Exception e)
        {
            Console.WriteLine("Исключение : {0}", e.Message);

        }

        return ret_val;

    }

    public void PrintCollection()
    {
        /* вывод элементов коллекции на консоль */

        Console.WriteLine("Содержимое коллекции : ");

        foreach (T x in TheCollection)
        {
            if ((x as PayCardCredit) != null) Console.WriteLine("Элемент коллекции : {0} ", (x as PayCardCredit).ToString());

            else Console.WriteLine("Элемент коллекции : {0} ", x.ToString());

        }

        if (TheCollection.Count == 0) Console.WriteLine("Коллекция пуста");
    }

    public T SearchInCollection(Predicate<T> varpred)
    {
        /* поиск конкретного объекта в коллекции по предикату */

        T ret_val = default(T);

        foreach (T x in TheCollection)
        {
            if (varpred(x))
            {
                ret_val = x;
                break;
            }
        }

        return ret_val;

    }

    public bool CheckValNegative(int varnum)
    {
        /* 
          метод проверяет переменную на отрицательность,

          данный метод будет присвоен предикату в SearchInCollection() 

         */

        bool val_res = false;

        if (varnum < 0) val_res = true;

        return val_res;

    }

    public void SaveToFile(String fname)
    {
        /* метод сохраняет нашу коллекцию в файл */

        string jsonstr = JsonConvert.SerializeObject(this.TheCollection);

        // для записи в файл используем класс StreamWriter - создает поток для записи и связывает его с файлом на диске
        using (StreamWriter w = new StreamWriter(fname, false, System.Text.Encoding.Default))
        {
            w.WriteLine(jsonstr); // сохраняеи нашу строку с json текстом в файл
        }

    }

    public void ReadFromFile(String fname)
    {
        /* метод, инициализирующий коллекцию платежных карт данными из JSON-файла */

        using (StreamReader r = new StreamReader(fname))
        {
            string json = r.ReadToEnd();

            dynamic array = JsonConvert.DeserializeObject(json);
            foreach (var item in array)
            {
                string CNum = item.CardNumber;
                string Pin = item.PinCodeEncrypted;
                int CredAmt = item.CreditAmount;

                PayCardCredit newcard = new PayCardCredit(CNum, Pin, CredAmt);
                
                // рассматриваем коллекцию как коллекцию плаиежных карт
                (this as CollectionType<PayCardCredit>).Add(newcard);

            }
        }

    }

}

