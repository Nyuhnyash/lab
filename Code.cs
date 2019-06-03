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
        static List<int> data;
        int length;

        public List<int> Data { get => data; set => data = value; }
        public int Length { get => length; set => length = value; }

        public List<int> Sort(int i)
        {
            List<int> data = new List<int>();
            data.AddRange(Data);
            switch (i)
            {
                case 0:
                    return Bubble(data);
                case 1:
                    return Selection(data);
                case 2:
                    return Insertion(data);
                case 3:
                    return Radix(data);
                default:
                    return null;
            }
        }
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
        public List<int> Radix(List<int> data)
        {
            IList<IList<int>> digits = new List<IList<int>>();
            int maxLength = 1;
            for (int i = 0; i < maxLength; i++)
            {
                for (int j = 0; j < data.Count; j++)
                {
                    int digit = (int)((data[j] % Math.Pow(10, i + 1)) / Math.Pow(10, i));

                    digits[digit].Add(data[j]);
                }

                int index = 0;
                for (int k = 0; k < digits.Count; k++)
                {
                    IList<int> selDigit = digits[k];

                    for (int l = 0; l < selDigit.Count; l++)
                    {
                        data[index++] = selDigit[l];
                    }
                }
            }
            return data;
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
