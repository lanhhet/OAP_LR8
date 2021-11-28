/*
    Шейбак Дарья, гр3 курс 2, ИСИТ

    ЛР №8

2. Возьмите за основу лабораторную № 4 «Перегрузка операций» и сделайте из нее обобщенный тип (класс) CollectionType<T>, 
   в который вложите обобщённую коллекцию. Наследуйте в обобщенном классе интерфейс из п.1. 
   Реализуйте необходимые методы (добавления, удаления, поиска по предикату). 
   Добавьте обработку исключений c finally. Наложите какое-либо ограничение на обобщение.

   Итак : требуется создать обобщенный class CollectionType<T>, в который вложена (является членом) обобщенная коллекция <T>

3. Проверьте использование обобщения для стандартных типов данных - проверили на типе int.

4. Определить пользовательский класс, который будет использоваться в качестве параметра обобщения. 
   Для пользовательского типа взять класс из лабораторной №5 «Наследование».

5. Добавьте методы сохранения объектов обобщённого типа CollectionType<T> в файл и чтения из него ( на выбор: текстовый | xml | json).

   Т Е О Р И Я 

   Обобщенные коллекции - это те же самые обобщенные классы - это Классы обобщенных коллекций. 
   Большинство обобщенных классов коллекций дублируют необобщенные классы коллекций. 
   Но если вам не надо хранить объекты разных типов, то предпочтительнее использовать обобщенные коллекции.

   Классы обобщенных коллекций (находятся пространстве имен System.Collections.Generic) :
    List<T>: класс, представляющий последовательный список.
    Queue<T>: класс очереди объектов, работающей по алгоритму FIFO("первый вошел-первый вышел").
    Dictionary<TKey, TValue>: класс коллекции, хранящей наборы пар "ключ-значение".
    LinkedList<T>: класс двухсвязанного списка.
    SortedSet<T>: класс отсортированной коллекции однотипных объектов.
    SortedList<TKey, TValue>: класс коллекции, хранящей наборы пар "ключ-значение", отсортированных по ключу.
    SortedDictionary<TKey, TValue>: класс коллекции, хранящей наборы пар "ключ-значение", отсортированных по ключу.
    Stack<T>: класс стека однотипных объектов.


 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            // протестируем клаcc CollectionType для стандартного типа данных - для int
            Console.WriteLine("\nКОЛЛЕКЦИЯ ЦЕЛОЧИСЛЕННЫХ ЗНАЧЕНИЙ:");

            CollectionType<int> MyCollection = new CollectionType<int>();

            MyCollection.Add(194);
            MyCollection.Add(-8);
            MyCollection.Add(21);
            MyCollection.Add(-67);
            MyCollection.Add(505);

            MyCollection.PrintCollection(); // выведем коллекцию на консоль
            Console.WriteLine("Выведем элемент коллекции с индексом 3");
            MyCollection.View(3);

            Console.WriteLine("Извлечем из коллекции элемент : {0}", MyCollection.Delete().ToString());
            Console.WriteLine("Извлечем из коллекции элемент : {0}", MyCollection.Delete().ToString());
            MyCollection.PrintCollection(); // выведем коллекцию на консоль

            // осуществим поиск в коллекции по предикату - найдем первое отрицательное число в коллекции
            int first_negative = 0; // инициализируем нулем - 'не обнаружено отрицательных значений'
            try
            {
                // создадим предикат - в качестве него возьмем метод проверки переменной на отрицательность
                Predicate<int> Mypredicate = MyCollection.CheckValNegative;
                first_negative = MyCollection.SearchInCollection(Mypredicate);
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникло Исключение : {0}", e.Message);
            }
            finally
            {
                // выполнится в любом случае
                if (first_negative != 0) Console.WriteLine("Первое отрицательное число в коллекции : {0}", first_negative);
                else Console.WriteLine("Отрицательные члены коллекции не обнаружены");

            }

            // теперь в качестве параметра обобщения возьмем тип (класс) PayCardCredit
            Console.WriteLine("\nКОЛЛЕКЦИЯ ПЛАТЕЖНЫХ КАРТ :");

            CollectionType<PayCardCredit> MyCollection2 = new CollectionType<PayCardCredit>();
            MyCollection2.Add(new PayCardCredit("124124-124142-421","3245", 5000));
            MyCollection2.Add(new PayCardCredit("646124-163642-331","2155", 2000));
            MyCollection2.Add(new PayCardCredit("125254-174774-423","3525", 12000));
            MyCollection2.PrintCollection();
            Console.WriteLine("Выведем элемент коллекции с индексом 2");
            MyCollection2.View(2);

            // сохраним наш объект обобщенного типа в файл
            Console.WriteLine("\nсохраним наш объект обобщенного типа в файл CARDS.JSON");
            MyCollection2.SaveToFile("CARDS.JSON");

            Console.WriteLine("Извлечем из коллекции элемент : {0}", MyCollection2.Delete().ToString());
            Console.WriteLine("Извлечем из коллекции элемент : {0}", MyCollection2.Delete().ToString());
            Console.WriteLine("Извлечем из коллекции элемент : {0}", MyCollection2.Delete().ToString());
            MyCollection2.PrintCollection();

            // заполним наш объект обобщенного типа из файла
            Console.WriteLine("\nзаполним наш объект обобщенного типа из файла CARDS.JSON");
            MyCollection2.ReadFromFile("CARDS.JSON");
            MyCollection2.PrintCollection();

            Console.ReadKey();

        }
    }
}
