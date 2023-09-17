using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class IterationMethod
{
    private EvaluateClass evaluate;
    public IterationMethod() => evaluate = new EvaluateClass();

    public void Iteration(string exp, double pZero, double epsilon, int roundDigit)
    {
        decimal differ;
        double before = evaluate.Evaluate(evaluate.f(exp, pZero), roundDigit); // n=1
        differ = (decimal)Math.Abs((pZero - before));
        System.Console.WriteLine("for n = {0}, P{1} = {2} \n|P{0} - P{1}| => |{3} - {2}| = {4} {5} {6}\n", 1, 0, pZero, before, differ, differ > (decimal)epsilon ? ">" : "<", ((decimal)epsilon).ToString());
        double after = evaluate.Evaluate(evaluate.f(exp, before), roundDigit); // n=2
        differ = (decimal)Math.Abs((after - before));
        System.Console.WriteLine("for n = {0}, P{1} = {2} \n|P{0} - P{1}| => |{3} - {2}| = {4} {5} {6}\n", 2, 1, after, before, differ, differ > (decimal)epsilon ? ">" : "<", ((decimal)epsilon).ToString());

        int n = 3;
        while (Math.Abs((after - before)) > epsilon)
        {
            before = after;
            after = evaluate.Evaluate(evaluate.f(exp, before), roundDigit);
            differ = (decimal)Math.Abs((after - before));
            System.Console.WriteLine("for n = {0}, P{1} = {2} \n|P{0} - P{1}| => |{3} - {2}| = {4} {5} {6}\n", n, n - 1, after, before, differ.ToString(), differ > (decimal)epsilon ? ">" : "<", ((decimal)epsilon).ToString());
            n++;
        }

        System.Console.WriteLine();
        System.Console.WriteLine("The root of it is " + after);
    }

    public void Iteration(string exp, double pZero, double epsilon, int roundDigit, double realRoot)
    {
        double before = evaluate.Evaluate(evaluate.f(exp, pZero), roundDigit); // n=1
        System.Console.WriteLine("for n = {0}, P{1} = {2}", 1, 0, before);
        double after = evaluate.Evaluate(evaluate.f(exp, before), roundDigit); // n=2
        System.Console.WriteLine("for n = {0}, P{1} = {2}", 2, 1, after);

        int n = 3;
        while (Math.Abs((realRoot - after)) > epsilon)
        {
            before = after;
            after = evaluate.Evaluate(evaluate.f(exp, before), roundDigit);
            System.Console.WriteLine("for n = {0}, P{1} = {2}", n, n - 1, after);
            n++;
        }

        System.Console.WriteLine();
        System.Console.WriteLine("The root of it is " + after);
    }
}