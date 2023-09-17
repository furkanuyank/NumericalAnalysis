public class EvaluateClass
{
    private bool HasPrecedence(char op1, char op2)
    {
        if (op2 == '(' || op2 == ')')
        {
            return false;
        }
        if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
        {
            return false;
        }
        if (op1 == '^' && (op2 == '*' || op2 == '/' || op2 == '+' || op2 == '-'))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private double ApplyOp(char op, double b, double a)
    {
        switch (op)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                if (b == 0)
                {
                    throw new
                    System.NotSupportedException(
                        "Cannot divide by zero");
                }
                return a / b;
            case '^':
                return Math.Pow(a, b);
        }
        return 0;
    }

    public double Evaluate(string expression, int digits)
    {
        char[] tokens = expression.ToCharArray();

        Stack<double> numbers = new Stack<double>();
        Stack<char> ops = new Stack<char>();

        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == ' ')
            {
                continue;
            }

            if (tokens[i] == 'e')
            {
                numbers.Push(2.71828182846);
            }

            if ((tokens[i] >= '0' && tokens[i] <= '9') || (tokens[i] == '.' || tokens[i] == ','))
            {
                System.Text.StringBuilder number = new System.Text.StringBuilder();

                while (i < tokens.Length && ((tokens[i] >= '0' && tokens[i] <= '9') || tokens[i] == '.'))
                {
                    number.Append(tokens[i++]);
                }
                numbers.Push(double.Parse(number.ToString()));
                i--;
            }


            else if (tokens[i] == '(')
            {
                ops.Push(tokens[i]);
            }

            else if (tokens[i] == ')')
            {
                while (ops.Peek() != '(')
                {
                    numbers.Push(ApplyOp(ops.Pop(), numbers.Pop(), numbers.Pop()));
                }
                ops.Pop();
            }

            else if (tokens[i] == '+' || tokens[i] == '-' || tokens[i] == '*' || tokens[i] == '/' || tokens[i] == '^')
            {
                while (ops.Count > 0 && HasPrecedence(tokens[i], ops.Peek()))
                {
                    numbers.Push(ApplyOp(ops.Pop(), numbers.Pop(), numbers.Pop()));
                }
                ops.Push(tokens[i]);
            }
        }

        while (ops.Count > 0)
        {
            numbers.Push(ApplyOp(ops.Pop(), numbers.Pop(), numbers.Pop()));
        }

        return double.Round(numbers.Pop(), digits, MidpointRounding.AwayFromZero);
    }

    public string f(string exp, double x)
    {
        char oldChar = 'x';
        string strVal = x.ToString();
        string newExp = "";

        string[] array = exp.Split(oldChar);

        for (int i = 0; i < array.Length - 1; i++)
        {
            newExp += array[i];
            newExp += strVal;
        }
        newExp += array[array.Length - 1];

        return newExp;
    }
}