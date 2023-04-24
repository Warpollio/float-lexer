using System;

class Program
{
    enum States
    {
        Start,
        Sign,
        Integer,
        Separator,
        AfterSeparator,
        Exponent,
        ExponentSign,
        ExponentValue
    }

    //"Number" ::= ["Sign"] "digit" {"digit"} ["Separator" "digit" {"digit"}]["Exponent" ["Sign"] "digit" {digit"}]

    static void Main()
    {
        string input = Console.ReadLine();
        if (IsValidNumber(input))
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }

    static bool IsValidNumber(string input)
    {
        int index = 0;
        States state = States.Start;

        while (index < input.Length)
        {
            char c = input[index];

            switch (state)
            {
                case States.Start:
                    if (c == '+' || c == '-')
                    {
                        state = States.Sign;
                    }
                    else if (char.IsDigit(c))
                    {
                        state = States.Integer;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case States.Sign:
                    if (char.IsDigit(c))
                    {
                        state = States.Integer;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case States.Integer:
                    if (char.IsDigit(c))
                    {
                        //States.Integer
                    }
                    else if (c == '.')
                    {
                        state = States.Separator;
                    }
                    else if (c == 'e' || c == 'E')
                    {
                        state = States.Exponent;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case States.Separator:
                    if (char.IsDigit(c))
                    {
                        state = States.AfterSeparator;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case States.AfterSeparator:
                    if (char.IsDigit(c))
                    {
                        //States.AfterSeparator
                    }
                    else if (c == 'e' || c == 'E')
                    {
                        state = States.Exponent;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case States.Exponent:
                    if (c == '+' || c == '-')
                    {
                        state = States.ExponentSign;
                    }
                    else if (char.IsDigit(c))
                    {
                        state = States.ExponentValue;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case States.ExponentSign:
                    if (char.IsDigit(c))
                    {
                        state = States.ExponentValue;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case States.ExponentValue:
                    if (char.IsDigit(c))
                    {
                        //States.ExponentValue
                    }
                    else
                    {
                        return false;
                    }
                    break;
            }

            index++;
        }

        return state == States.Integer || state == States.AfterSeparator || state == States.ExponentValue;
    }
}
