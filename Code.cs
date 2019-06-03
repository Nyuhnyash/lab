using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    public class Sorting
    {
        public Sorting()
        {
            Data = new List<int>();
            Length = 0;
        }
        public Sorting(int length)
        {
            Data = new List<int>();
            this.Length = length;
        }
        List<int> data, dataBubble;
        int length;

        public List<int> Data { get => data; set => data = value; }
        public List<int> DataBubble { get => dataBubble; set => dataBubble = value; }
        public int Length { get => length; set => length = value; }

        public List<int> Bubble() =>  Bubble(data);
        public List<int> Bubble(List<int> data)
        {
            int temp;
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (data[i] > data[j])
                    {
                        temp = data[i];
                        data[i] = data[j];
                        data[j] = temp;
                    }
                }
            }
            return data;
        }
        public List<int> Selection() => Selection(data);
        public List<int> Selection(List<int> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (data[j] < data[min])
                    {
                        min = j;
                    }
                }
                int dummy = data[i];
                data[i] = data[min];
                data[min] = dummy;
            }
            return data;
        }
        public List<int> Insertion() => Insertion(data);
        public List<int> Insertion(List<int> data)
        {
            for (int i = 1; i < data.Count; i++)
            {
                int cur = data[i];
                int j = i;
                while (j > 0 && cur < data[j - 1])
                {
                    data[j] = data[j - 1];
                    j--;
                }
                data[j] = cur;
            }
            return data;
        }
        public List<int> Radix() => Radix(data);
        public List<int> Radix(List<int> data)
        {
            return null;
        }

        public void Random()
        {
            Random rand = new Random();
            for (int i = 0; i < Length; i++)
            {
                Data.Add(rand.Next(10));
            }
        }
    }
}
