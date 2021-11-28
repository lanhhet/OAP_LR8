using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IMYopers<T> // обобщенный интерфейc
{
    void Add(T varobj);  // добавить
    T Delete();          // удалить
    T View(int idx);     // просмотреть

}

public class BookLibrary<T> : IMYopers<T>
{
    List<T> obj_list = null;  // коллекция объектов типа T

    public BookLibrary() // конструктор
    {
        obj_list = new List<T>();
    }

    public void Add(T varobj)
    {
        /* добавить объект в коллекцию */

        obj_list.Add(varobj);

    }
    public T Delete()
    {
        /* удалить первый объект из коллекции и вернуть его */

        T ret_val = default(T); // инициализируем (default(T) означает, что если T - cсылочный тип, то присваивается null, а если тип значений - значение 0)

        if (obj_list.Count > 0) // в коллекции есть элементы
        {

            ret_val = obj_list.ElementAt(0); // берем значение первого объекта в коллекции (с индеком 0)

            obj_list.RemoveAt(0); // удаляет первый объект в коллекции (с индексом 0)
        }

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

        ret_val = obj_list.ElementAt(varidx); // возвращает элемент по указанному индексу, вызывает исключение, если индекс меньше 0 либо больше старшего имеющегося

        // выведем на консоль - просмотр
        Console.WriteLine("Значение объекта : {0}", ret_val);

        }
        catch (Exception e)
        {
            Console.WriteLine("Исключение : {0}", e.Message);

        }

        return ret_val;

    }

}
