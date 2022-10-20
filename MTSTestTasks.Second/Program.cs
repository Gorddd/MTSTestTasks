using System;
using System.Globalization;

class Program
{
    static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

    class Number
    {
        readonly int _number;

        public Number(int number)
        {
            _number = number;
        }

        public static string operator +(Number fNum, string sNum)
        {
            int parsedSNum = ValidateNum(sNum);

            return (fNum._number + parsedSNum).ToString();
        }

        public static Number operator +(Number fNum, Number sNum) =>
            new Number(fNum._number + sNum._number);

        public static int operator +(Number fNum, int sNum) =>
            fNum._number + sNum;

        private static int ValidateNum(string num)
        {
            if (int.TryParse(num, out int parsedNum))
                return parsedNum;
            else
                throw new ArgumentException($"Can't parse {num} to int");
        }

        public override string ToString()
        {
            return _number.ToString(_ifp);
        }
    }

    static void Main(string[] args)
    {
        int someValue1 = 10;
        int someValue2 = 5;

        string result = new Number(someValue1) + someValue2.ToString(_ifp);
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
