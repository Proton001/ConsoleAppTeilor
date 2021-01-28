using System;

namespace ConsoleAppTeilor
{
	class Program
	{
		static void Main(string[] args)
		{
			bool b = false;
			bool error = false;
			decimal Xn = 0;
			decimal Xk = 0;
			decimal dx = 0;
			decimal eps = 0;
			int n;
			decimal result;
			decimal x;
			decimal t;
			string text = null;

			while (b == false)
			{
				try
				{
					Console.Write("Введите x нач.: ");

					Xn = decimal.Parse(Console.ReadLine());
					b = true;
					Console.WriteLine("--------------------------------------------------");
					Console.WriteLine("| x начальное = {0,32} |", Xn);
					Console.WriteLine("--------------------------------------------------");

				}
				catch (FormatException)
				{

					Console.WriteLine("Вы не ввели значение в переменную или ввели его неверно.", "Number or value error!!!");
					b = false;
				}
				catch (OverflowException)
				{
					Console.WriteLine("Вы ввели слишком большое значение.\rПопробуйте снова.", "Too long number or value Error!!!");
					b = false;

				}
			}
			b = false;

			while (Xk <= Xn)
			{
				try
				{
					Console.Write(text);
					Console.Write("Введите x кон. ");
					Xk = decimal.Parse(Console.ReadLine());
					text = "Xk должно быть больше Xn. ";
					Console.WriteLine("--------------------------------------------------");
					Console.WriteLine("| x конечное = {0,35} |", Xk);
					Console.WriteLine("--------------------------------------------------");

				}
				catch (FormatException)
				{

					Console.WriteLine("Вы не ввели значение в переменную или ввели его неверно.", "Number or value error!!!");
					b = false;
				}
				catch (OverflowException)
				{
					Console.WriteLine("Вы ввели слишком большое значение.\rПопробуйте снова.", "Too long number or value Error!!!");
					b = false;

				}
			}
			text = null;

			while (dx <= 0)
			{
				try
				{
					Console.Write("Введите шаг dx: ");
					dx = decimal.Parse(Console.ReadLine());
					Console.WriteLine("--------------------------------------------------");
					Console.WriteLine("| Шаг dx = {0,37} |", dx);
					Console.WriteLine("--------------------------------------------------");
				}
				catch (FormatException)
				{

					Console.WriteLine("Вы не ввели значение в переменную или ввели его неверно.", "Number or value error!!!");
					b = false;
				}
				catch (OverflowException)
				{
					Console.WriteLine("Вы ввели слишком большое значение.\rПопробуйте снова.", "Too long number or value Error!!!");
					b = false;

				}
			}

			while (eps <= 0)
			{
				try
				{
					Console.Write("Введите точность е:  ");
					eps = decimal.Parse(Console.ReadLine()); //точность
					Console.WriteLine("--------------------------------------------------");
					Console.WriteLine("| Точность = {0,37} |", eps);
					Console.WriteLine("--------------------------------------------------");
				}
				catch (FormatException)
				{

					Console.WriteLine("Вы не ввели значение в переменную или ввели его неверно.", "Number or value error!!!");
					b = false;
				}
				catch (OverflowException)
				{
					Console.WriteLine("Вы ввели слишком большое значение.\rПопробуйте снова.", "Too long number or value Error!!!");
					b = false;

				}
			}

			x = Xn;

			Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
			Console.WriteLine("|  Аргумент X  |                 Функция y                 |    Количество слагаемых n    |           Проверка e^x          |");
			Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
			Console.WriteLine();
			while (x <= Xk && error != true)
			{
				n = 0; //текущий шаг
				t = 1; //текущий член ряда                          
				result = t; // Сумммма

				while (Math.Abs(t) >= eps && error != true)
				{
					n += 1;
					try
					{
						t = -t * x / n; //((Math.Pow(-1, n) * Math.Pow((x), n)) / (Factorial(n)));
						result = (decimal)(result + t);
					}
					catch (OverflowException)
					{
						Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
						Console.WriteLine("System.OverflowException: Value was either too large or too small for a Decimal.");
						Console.WriteLine("Дальнейшее вычисление невозможно");
						Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
						error = true;

					}
				}
				if (error == false)
				{
					Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
					Console.WriteLine("| {0,-12} | \t{1, 34} | \t{2,25} | \t{3,26} |", x, result, n, Math.Exp((double)(-x)));
				}

				x += dx;
			}
			Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
			Console.WriteLine("Нажмите любую клавишу, что бы закрыть консоль");
			Console.ReadKey();

		}
	}
}