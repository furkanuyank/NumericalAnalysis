using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BisectionMethod
{
    private EvaluateClass evaluate;
    public BisectionMethod() => evaluate = new EvaluateClass();

    public void Bisection(string exp, double a, double b, double epsilon, int roundDigit)
    {
        double mid = (a + b) / 2;
        int n = 0;
        while (Math.Abs(b - a) > epsilon)
        {
            System.Console.WriteLine("for n = {0},", n);
            double midResult = evaluate.Evaluate(evaluate.f(exp, mid), roundDigit);
            System.Console.WriteLine("\tf({0}) = {1}", mid, ((decimal)midResult).ToString());
            if (midResult * b < 0)
            {
                a = mid;
            }
            else
            {
                b = mid;
            }
            System.Console.WriteLine("\t[{0} , {1}]\n", a, b);
            mid = (a + b) / 2;
            n++;
        }

        System.Console.WriteLine("The root is between {0} and {1} avarge of it is {2}", a, b, (mid - a) > (b - mid) ? b : a);
    }
}