using System;

namespace Assignment1_S19
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("1.Print Prime Numbers");
            int a = 5; int b = 25;
            printPrimeNumbers(a, b);

            Console.WriteLine("2.Print Series");
            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("The sum of the series is: " + r1);

            Console.WriteLine("3.Print Decimal to Binary Conversion");
            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);

            Console.WriteLine("4.Print Binary to Decimal Conversion");
            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);

            Console.WriteLine("5.Print Triangle");
            int n4 = 1;
            printTriangle(n4);

            Console.WriteLine("6.Print Frequency of numbers in Array");
            // Ask user to input number of elements in an array
            Console.WriteLine("Enter Size of Array");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size]; //{ 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);

            // write your self-reflection here as a comment
            Console.WriteLine("*************************Learning*************************");
            Console.WriteLine("1.Using different methods has improved my understanding on how to call a method,its appropriate usage and return types");
            Console.WriteLine("2.Each Method was composed of some internal logic which needs to applied for getting the desired output");
            Console.WriteLine("3.Gave better understanding for datatypes,variables,conditions,loops,arrays and other basic concepts");
            Console.WriteLine("4.Better understaning of decision making and how to handle exceptions and corner cases");
            Console.WriteLine("**********************Recommendations**********************");
            Console.WriteLine("Can have some method or internal logic which deals with :");
            Console.WriteLine("1.Date and time");
            Console.WriteLine("2.In-built functions which are commonly used");

            Console.ReadKey();
        }

        public static void printPrimeNumbers(int x, int y)
        {
            try
            {
                //Console.WriteLine("1.Print Prime Numbers");
                // To check that starting number is always > 1 and if not then display message and ask user to enter a number > 1
                Console.WriteLine("Enter Starting Number of Range");
                x = Convert.ToInt32(Console.ReadLine());
                while (x <= 1)
                {
                    Console.WriteLine("Please enter different value of Starting Number which is >1");
                    Console.WriteLine("Enter Starting Number of Range");
                    x = Convert.ToInt32(Console.ReadLine());
                }
                // To check Ending Number is always > the starting number
                Console.WriteLine("Enter Ending Number of Range");
                y = Convert.ToInt32(Console.ReadLine());
                while (x > y)
                {
                    Console.WriteLine("Please enter different value of Ending Number which is > Starting Number");
                    Console.WriteLine("Enter Ending Number of Range");
                    y = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Prime Numbers between {0} and {1} are:", x, y);
                for (int a = x; a <= y; a++)
                {
                    if (IsPrime(a))
                    {
                        Console.Write(a + ",");
                    }
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers() :" + e);
            }

        }

        public static double getSeriesResult(int n)
        {
            try
            {
                //Console.WriteLine("2.Print Series");
                // Allow user to input any number which is greater than 0
                Console.WriteLine("Input any number greater than 0");
                n = Convert.ToInt32(Console.ReadLine());

                int fact;
                double result1;
                double result2 = 0;
                // If the number enter is less than or 0 then display the below message
                if (n <= 0)
                {
                    Console.WriteLine("Please enter number greater than 0. Series Sum will be 0 as it is not calculated for the numbers less than 0");
                }
                // Calculate the sum of the series
                else
                {
                    for (int x = 1; x <= n; x++)
                    {
                        fact = getFact(x);// Get the factorial value from getFact() method
                        int b = x + 1;// to get the value of denominater
                        result1 = Convert.ToDouble(fact) / Convert.ToDouble(b);
                        // If the term is even the result will be multiplied by -1 to get negative value
                        if (x % 2 == 0)
                        {
                            result1 = result1 * (-1);

                        }
                        // If the term is odd the result will be taken as is
                        else
                        {
                            result1 = result1;

                        }
                        result2 += result1;
                    }
                }
                return result2;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing getSeriesResult():" + e.Message);
            }

            return 0;
        }
        public static long decimalToBinary(long n)
        {
            try
            {
                //Console.WriteLine("3.Print Decimal to Binary Conversion");
                // Allow user to input any number positive number
                Console.WriteLine("Input any Positive Number");
                n = Convert.ToInt64(Console.ReadLine());
                // Compute Binary code if the number is >= 0
                if (n >= 0)
                {
                    // Logic to get the binary output
                    long mod;
                    string m = "";// empty string to hold remainder values
                    while (n >= 1)
                    {
                        mod = n % 2; // to get remainder
                        n = n / 2; // to get quotient and apply the same logic till quotient becomes 0
                        m += mod.ToString();//Concatenate all the remainders computed
                    }
                    // To reverse the string output which was derived above to get the correct Binary Value
                    int len;
                    string revm = "";
                    len = m.Length;
                    for (int i = len - 1; i >= 0; i--)
                    {
                        revm = revm + m[i];
                    }
                    return Convert.ToInt64(revm);
                }
                //If the number entered is negative then display the below message
                else
                {
                    Console.WriteLine("Please enter a number which is positive [>=0]");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing decimalToBinary():" + e.Message);

            }

            return 0;

        }
        public static long binaryToDecimal(long n)
        {
            try
            {
                //Console.WriteLine("4.Print Binary to Decimal Conversion");
                // Allow user to input any number positive number
                Console.WriteLine("Input Any Binary Number");
                string s = Console.ReadLine();
                n = Convert.ToInt64(s);
                if (IsBinary(s))// Calls method IsBinary() to check if the number entered is Binary or not
                {
                    // Logic to get the decimal output
                    string m = Convert.ToString(n);
                    int len;
                    string x = "";
                    double y = 0;
                    len = m.Length;
                    int power = 0;
                    int calc = 1;
                    for (int i = 0; i < len; i++)
                    {
                        x = Convert.ToString(m[i]);
                        power = (len - 1) - i; // Get the power 
                        calc = getPower(power);    // Get the 2^n from getPower() method                
                        //Console.WriteLine(calc);
                        y = y + (Convert.ToDouble(x) * calc);

                    }
                    return Convert.ToInt64(y);
                }
                //If the number entered is not binary then display the below message
                else
                {
                    Console.WriteLine("Number entered is not Binary.Please Enter a positive number which is Binary having 0s and 1s only");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal():" + e.Message);

            }

            return 0;

        }
        public static void printTriangle(int n)
        {

            try
            {
                //Console.WriteLine("5.Print Triangle");
                // Allow user to input any number of lines to see in the output
                Console.WriteLine("Enter Number of Lines to be displayed in the triangle");
                n = Convert.ToInt32(Console.ReadLine());
                string m = "";
                if (n >= 2)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        int p = n - i;
                        if (i == 1)
                        {
                            m = "*";
                        }
                        else
                        {
                            m = m + "**";

                        }
                        // To add spaces before the pattern based on line number
                        string spaces = new String(' ', p);

                        Console.WriteLine(spaces + m);

                    }
                }
                else if (n == 1)
                {
                    Console.WriteLine("*");
                    Console.WriteLine("Not enough lines to form a triangle.Enter Value greater than 1");
                }
                else
                {
                    Console.WriteLine("Numbers of lines entered {0} which is not valid value to create a triangle.Please enter numbers > 1", n);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing printTriangle():" + e.Message);
            }
        }
        public static void computeFrequency(int[] a)
        {
            try
            {

                // Allow user to input numbers for the array based on the given size
                Console.WriteLine("Input Array Values");
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = Convert.ToInt32(Console.ReadLine());
                }
                int y = a.Length;
                int k; int count;
                int[] freq = new int[y];
                Console.WriteLine("Number" + " " + "Frequency");
                for (k = 0; k < y; k++)
                {
                    freq[k] = -1;// Set frequency to -1

                }

                for (k = 0; k < y; k++)
                {
                    count = 1;
                    for (int j = k + 1; j < y; j++)
                    {
                        if (a[k] == a[j]) // To check if the number occurs again in the array
                        {
                            count = count + 1;
                            freq[j] = 0; // Set freq to 0 if the number is found again to make sure the frequency is not to counted more than once
                        }

                    }
                    // To set frequency to 1 for the number which appear once in the array
                    if (freq[k] != 0)
                    {
                        freq[k] = count;
                    }

                }
                // To display the output in the desired format "Number Frequency"
                for (k = 0; k < y; k++)
                {
                    if (freq[k] != 0)
                    {
                        Console.WriteLine(" " + a[k] + '\t' + freq[k]);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing computeFrequency():" + e.Message);
            }
        }

        // IsPrime() method to check if the number is prime or not and return prime number.
        public static bool IsPrime(int num)
        {
            for (int i = 2; i < num; i++)
                if (num % i == 0)
                    return false;
            return true;
        }
        //getFact() method to calculate the factorial of the number
        public static int getFact(int num)
        {
            int fact = 1;
            for (int x = 1; x <= num; x++)
            {
                fact = fact * x;
            }
            return fact;
        }

        //getPower() method to calculate the 2^n 
        public static int getPower(int num)
        {
            int power = 1;
            for (int x = 1; x <= num; x++)
            {
                power *= 2;
            }
            return power;
        }
        //IsBinary() method to check if the number entered by user is binary or not
        static bool IsBinary(string str)
        {
            foreach (var i in str)
                if (i != '0' && i != '1')
                    return false;
            return true;
        }

    }
}
