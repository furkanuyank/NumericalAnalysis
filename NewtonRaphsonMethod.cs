using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class NewtonRaphsonMethod
{
    private EvaluateClass evaluate;
    public NewtonRaphsonMethod() => evaluate = new EvaluateClass();

    public void NewtonRaphson(string normal, string derivative, double xZero, double epsilon, int roundDigit)
    {
        decimal result;
        double top = evaluate.Evaluate(evaluate.f(normal, xZero), roundDigit);
        double bot = evaluate.Evaluate(evaluate.f(derivative, xZero), roundDigit);
        double before = double.Round(xZero - (top / bot), roundDigit, MidpointRounding.AwayFromZero);
        System.Console.WriteLine("for n = {0},", 0); // n=0
        System.Console.WriteLine("\tX{0} = X{1} - ( f(X{1}) / f'(X{1}) ) = {2} - ( {3} / {4} ) = {5}", 1, 0, xZero, top, bot, before);
        System.Console.WriteLine("\tX{0} = {1}", 1, before);
        result = (decimal)(Math.Abs((xZero - before)));
        System.Console.WriteLine("\t|X{0} - X{1}| = {2} {3} {4}\n", 1, 0, result, result > (decimal)epsilon ? ">" : "<", ((decimal)epsilon).ToString());

        top = evaluate.Evaluate(evaluate.f(normal, before), roundDigit);
        bot = evaluate.Evaluate(evaluate.f(derivative, before), roundDigit);
        double after = double.Round(before - (top / bot), roundDigit, MidpointRounding.AwayFromZero);
        System.Console.WriteLine("for n = {0},", 1); // n=1
        System.Console.WriteLine("\tX{0} = X{1} - ( f(X{1}) / f'(X{1}) ) = {2} - ( {3} / {4} ) = {5}", 2, 1, before, top, bot, after);
        System.Console.WriteLine("\tX{0} = {1}", 2, after);
        result = (decimal)(Math.Abs((after - before)));
        System.Console.WriteLine("\t|X{0} - X{1}| = {2} {3} {4}\n", 2, 1, result.ToString(), result > (decimal)epsilon ? ">" : "<", ((decimal)epsilon).ToString());

        int n = 2;
        while (Math.Abs((after - before)) > epsilon)
        {
            before = after;
            top = evaluate.Evaluate(evaluate.f(normal, before), roundDigit);
            bot = evaluate.Evaluate(evaluate.f(derivative, before), roundDigit);
            after = double.Round(before - (top / bot), roundDigit, MidpointRounding.AwayFromZero);
            System.Console.WriteLine("for n = {0},", n);
            System.Console.WriteLine("\tX{0} = X{1} - ( f(X{1}) / f'(X{1}) ) = {2} - ( {3} / {4} ) = {5}", n + 1, n, before, ((decimal)top).ToString(), ((decimal)bot).ToString(), after);
            System.Console.WriteLine("\tX{0} = {1}", n + 1, after);
            result = (decimal)(Math.Abs((after - before)));
            System.Console.WriteLine("\t|X{0} - X{1}| = {2} {3} {4}\n", n + 1, n, result, result > (decimal)epsilon ? ">" : "<", ((decimal)epsilon).ToString());
            n++;
        }
        System.Console.WriteLine("So the root of it is " + after);
    }

    public void NewtonRaphson(string normal, string derivative, double xZero, double epsilon, int roundDigit, double realRoot)
    {
        decimal result;
        double top = evaluate.Evaluate(evaluate.f(normal, xZero), roundDigit);
        double bot = evaluate.Evaluate(evaluate.f(derivative, xZero), roundDigit);
        double before = double.Round(xZero - (top / bot), roundDigit, MidpointRounding.AwayFromZero);
        System.Console.WriteLine("for n = {0},", 0); // n=0
        System.Console.WriteLine("\tX{0} = X{1} - ( f(X{1}) / f'(X{1}) ) = {2} - ( {3} / {4} ) = {5}", 1, 0, xZero, top, bot, before);
        System.Console.WriteLine("\tX{0} = {1}", 0, before);
        result = (decimal)(Math.Abs((realRoot - before)));
        System.Console.WriteLine("\t|X - X{0}| = {1} {2} {3}\n", 1, result, result > (decimal)epsilon ? ">" : "<", ((decimal)epsilon).ToString());

        top = evaluate.Evaluate(evaluate.f(normal, before), roundDigit);
        bot = evaluate.Evaluate(evaluate.f(derivative, before), roundDigit);
        double after = double.Round(before - (top / bot), roundDigit, MidpointRounding.AwayFromZero);
        System.Console.WriteLine("for n = {0},", 1); //n=1
        System.Console.WriteLine("\tX{0} = X{1} - ( f(X{1}) / f'(X{1}) ) = {2} - ( {3} / {4} ) = {5}", 2, 1, before, top, bot, after);
        System.Console.WriteLine("\tX{0} = {1}", 2, after);
        result = (decimal)(Math.Abs((realRoot - after)));
        System.Console.WriteLine("\t|X - X{0}| = {1} {2} {3}\n", 2, result.ToString(), result > (decimal)epsilon ? ">" : "<", ((decimal)epsilon).ToString());

        int n = 2;
        while (Math.Abs((realRoot - after)) > epsilon)
        {
            before = after;
            top = evaluate.Evaluate(evaluate.f(normal, before), roundDigit);
            bot = evaluate.Evaluate(evaluate.f(derivative, before), roundDigit);
            after = double.Round(before - (top / bot), roundDigit, MidpointRounding.AwayFromZero);
            System.Console.WriteLine("for n = {0},", n);
            System.Console.WriteLine("\tX{0} = X{1} - ( f(X{1}) / f'(X{1}) ) = {2} - ( {3} / {4} ) = {5}", n + 1, n, before, top, bot, after);
            System.Console.WriteLine("\tX{0} = {1}", n + 1, after);
            result = (decimal)(Math.Abs((realRoot - after)));
            System.Console.WriteLine("\t|X - X{0}| = {1} {2} {3}\n", n + 1, result, result > (decimal)epsilon ? ">" : "<", ((decimal)epsilon).ToString());
            n++;
        }
        System.Console.WriteLine("So the root of it is " + after);
    }
}