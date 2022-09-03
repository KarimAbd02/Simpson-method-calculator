using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public delegate double Function(double x);
    class Program
    {
        static double RightRectangle(Function f, double a, double b, double n)
        {
            var h = (b - a) / n;
            var sum = 0d;
            for (var i = 1; i <= n; i++)
            {
                var x = a + i * h;
                sum += f(x);
            }

            var result = h * sum;
            return result;
        }
        public static double SimpsonMethod(Function f, double b, double a, double n)
        {
            double sum = 0;
            double h = (b - a) / n;
            for (int i = 0; i < n; i++)
                sum += (f(a + h * i) + 4 * f(a + h * (i + 0.5)) + f(a + h * (i + 1)) * h / 6 );
            return sum;
        }

        static double Trapezium(Function func, double n, double a, double b)
        {
            double x, h, s;
            h = (b - a) / n; 
            s = (func(a) + func(b)) / 2; 
            for (x = a + h; x < b; x += h)
            {
                s += func(x); 
            }
            return s * h; //домножаем на шаг
        }

        public static double SimpsonMethod_For_x(double x)
        {
            x = Math.Sin(18)/x/8;
            return x;
        }

        public static double RightRectangle_For_e(double e)
        {
            e = Math.Sin(18) / e / 8;
            return e;
        }

        public static double Trapezium_for_t(double t)
        {

            t = Math.Sin(18) / t / 8;
            return t;
        }

        public static double SimpsonMethod_For_x1(double x)
        {
            x = x / (Math.Pow(x, 2) + 0.1);
            return x;
        }

        public static double RightRectangle_For_e1(double e)
        {
            e = e / (Math.Pow(e, 2) + 0.1);
            return e;
        }

        public static double Trapezium_for_t1(double t)
        {

            t = t /(Math.Pow(t,2)+0.1) ;
            return t;
        }

        static void Main(string[] args)
        {
            try
            {
                Function sim = new Function(SimpsonMethod_For_x);
                Function resalt = new Function(RightRectangle_For_e);
                Function trapez = new Function(Trapezium_for_t);
                Function sim1 = new Function(SimpsonMethod_For_x1);
                Function resalt1 = new Function(RightRectangle_For_e1);
                Function trapez1 = new Function(Trapezium_for_t1);
                double a, b;
                double n;
                Console.WriteLine("Омельков К.С.\nВариант №18\nПрактическая работа №8");
                Console.Write("Нижняя граница интегрирования. a=");
                a = Double.Parse(Console.ReadLine());
                Console.Write("Верхняя граница интегрирования. b=");
                b = Double.Parse(Console.ReadLine());
                Console.Write("Количество шагов. n=");
                n = double.Parse(Console.ReadLine());
                Console.Write("1-ая функция: 18sin(x)/e^x/8");
                Console.Write("\nФормула метода симпсона = {0}", SimpsonMethod(sim, b, a, n));
                Console.Write("\nФормула метода правых прямоугольников = {0}", RightRectangle(resalt, b, a, n));
                Console.Write("\nФормула метода трапеций = {0}", Trapezium(trapez, b, a, n));

                Console.Write("\n \n2-ая функция: x/((x^2)+0.1)");
                Console.Write("\nФормула метода симпсона = {0}", SimpsonMethod(sim1, b, a, n));
                Console.Write("\nФормула метода правых прямоугольников = {0}", RightRectangle(resalt1, b, a, n));
                Console.Write("\nФормула метода трапеций = {0}", Trapezium(trapez1, b, a, n));
            }
            catch
            {
                Console.Write("\nНеправильно введены данные");
            }
            Console.ReadKey();
        }
    }

}

