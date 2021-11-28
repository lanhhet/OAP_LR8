/*
    Шейбак Дарья, гр3 курс 2, ИСИТ

    ЛР №8

1. Создайте обобщенный интерфейс с операциями добавить, удалить, просмотреть. 

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {

        // ЗАДАНИЕ 1

        BookLibrary<String> MyLibrary = new BookLibrary<String>();

        MyLibrary.Add("Робинзон Крузо");
        MyLibrary.Add("Джейн Остин");
        MyLibrary.Add("Гарри Потер");
        MyLibrary.Add("Чиполино");

        MyLibrary.View(1);  // Джейн Остин
        Console.WriteLine("Удалили элемент : {0}", MyLibrary.Delete()); // удаляем объект коллекции с индексом 0 - Робинзон Крузо 
        MyLibrary.View(1);  // Гарри Потер
        Console.WriteLine("Удалили элемент : {0}", MyLibrary.Delete()); // удаляем объект коллекции с индексом 0 - Джейн Остин
        MyLibrary.View(0);  // Гарри Потер
        MyLibrary.View(1);  // Чиполино


        Console.ReadKey();

        }

    }
