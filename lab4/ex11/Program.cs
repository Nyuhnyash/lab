using System;

namespace ex11 // кирпич a*b*c через отверстие d*e
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] A = new int[5];
			char c = 'a';
			for (int i = 0; i < 5; i++) {
				Console.Write(c + "=");
				c++;
				A[i] = int.Parse(Console.ReadLine());
			} 
			// Сортировка 0-2
			for (int i = 0; i < 3; i++)
				for (int j = i+1; j < 3; j++) {
					if (A[j] < A[i]) {
						int temp = A[i];
						A[i] = A[j];
						A[j] = temp;
					}
				}
			// Сортировка 3-4
			if (A[3] > A[4]) {
				int temp = A[3];
				A[3] = A[4];
				A[4] = temp;
			}
			if ((A[0] <= A[3]) && (A[1] <= A[4]))
				Console.WriteLine("YES");
			else
				Console.WriteLine("NO");
		}
	}
}