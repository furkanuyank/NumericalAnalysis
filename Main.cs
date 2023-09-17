using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        // Iteration Method
        IterationMethod iterationMethod = new IterationMethod();

        //Parameters ->
        //function (string) required
        //iteration starter value (double) required
        //margin of error (double) required
        //round digit (int) required
        //real root of function (double) optional, if it's known

        //Example
        //iterationMethod.Iteration("3/(4+(x^2))", 0.5, 0.0001, 6);


        // Newton Rapshon Method
        NewtonRaphsonMethod newtonRaphsonMethod = new NewtonRaphsonMethod();

        //Parameters ->
        //function (string) required
        //derivative of function (string) required
        //iteration starter value (double) required
        //margin of error (double) required
        //round digit (int) required
        //real root of function (double) optional, if it's known

        //Example
        //newtonRaphsonMethod.NewtonRaphson("(x^5)-16", "5*(x^4)", 2, 0.00001, 10);


        //Bisection Method
        BisectionMethod bisectionMethod = new BisectionMethod();

        //Parameters ->
        //function (string) required
        //min point of interval (double) required
        //max point of interval (double) required
        //margin of error (double) required
        //round digit (int) required

        // Example
        //bisectionMethod.Bisection("(x^5)-16", 1, 2, 0.00001, 7);
    }
}