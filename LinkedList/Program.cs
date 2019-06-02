using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            int ten = 10;
            Random rand = new Random();


            Train t = new Train();
            t.Add(ten);
            for (int i = 0; i < ten; i++)
            {
                t[i] = rand.Next(100);
                Console.WriteLine(t[i]);
            }
                
            Console.WriteLine();
            t.Insert(4);
            t[4] = 777;
            t.Remove();
            for (int i = 0; i < ten; i++)
                Console.WriteLine(t[i]);
        }
    }

    class Train
    {
         
        static Wagon first, // ссылка на первый вагон
                     last; // техническая ссылка на последний добавленный вагон

        public Train()
        {
            first = last = null;
        }

        public object this[int index]
        {
            get
            {
                if (ByIndex(index) == null)
                    return "null";
                else
                    return ByIndex(index).data;
            }
            set
            {
                if (ByIndex(index) != null)
                    ByIndex(index).data = value;
            }
        }
        Wagon ByIndex(int index)
        {
            Wagon w = first;
            for (int i = 0; i < index; i++)
                w = w.next;
            return w;
        }

        public void Add() // в конец
        {
            if (last == null)
            {
                last = first = new Wagon();
            }
            else
                last = new Wagon(last);
        }
        public void Add(int count)
        {
            for (int i = 0; i < count; Add(), i++); 
        }
        public void Remove() // с конца
        {
            last = last.prev; // предпоследний становится последним
            last.next = null; // предпоследний.next = null
        }
        public void Remove(int count)
        {
            for (int i = 0; i < count; Remove(), i++);
        }
        //public void Clear()
        //{
        //    first = last = null;
        //}
        public void Insert(int index)
        {
            Wagon old = ByIndex(index);
            Wagon nnew = new Wagon(ByIndex(index - 1));
            old.prev = nnew;
            nnew.next = old;
        }
    }

    class Wagon
    {
        public Wagon prev, next;
        public object data;

        public Wagon()
        {
            prev = next = null;
        }
        public Wagon(Wagon prev)
        {
            prev.next = this;
            this.prev = prev;
            this.next = null;
        }
    }
}
